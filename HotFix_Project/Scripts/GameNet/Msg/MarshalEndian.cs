﻿using GameNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// 消息解析器  
public class MarshalEndian: IMarshalEndian
{
    //用于存储剩余未解析的字节数  
    private List<byte> _LBuff;
    //默认是utf8的编码格式  
    private UTF8Encoding utf8;

    //包头1  
    const byte t1 = 0x28;
    //包头2  
    const byte t2 = 0x06;
    //字节数常量 两个包头4个字节，一个消息id4个字节，封装消息长度 int32 4个字节  
    const Int32 ConstLenght = 4;

    public IRemote Context { get; set; }
    public void Initialize()
    {
        _LBuff = new List<byte>(2);
        utf8 = new UTF8Encoding();
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool flag1)
    {
        if (flag1)
        {
            IDisposable disposable2 = this.utf8 as IDisposable;
            if (disposable2 != null) { disposable2.Dispose(); }
            IDisposable disposable = this._LBuff as IDisposable;
            if (disposable != null) { disposable.Dispose(); }
        }
    }

    public byte[] Encode(IBaseMessage msg)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (BinaryWriter bw = new BinaryWriter(ms, new UTF8Encoding()))
            {
                byte[] msgBuffer = msg.GetByte();

                #region 封装包头  
                bw.Write(t1);
                bw.Write(t2);
                #endregion

                int len = 0;
                #region 包协议  
                if (msgBuffer != null)
                {
                    len = msgBuffer.Length + 4;
                    bw.Write((Int16)(len));

                    bw.Write(msg.MsgID);//数据域
                    bw.Write(msgBuffer);//数据域
                }
                else { bw.Write((Int16)len); }
                #endregion

                return ms.ToArray();
            }
        }
    }

    public List<IBaseMessage> Decode(byte[] buff, int len)
    {
        //拷贝本次的有效字节  
        byte[] _b = new byte[len];
        Array.Copy(buff, 0, _b, 0, _b.Length);
        buff = _b;
        if (this._LBuff.Count > 0)
        {
            //拷贝之前遗留的字节  
            this._LBuff.AddRange(_b);
            buff = this._LBuff.ToArray();
            this._LBuff.Clear();
        }

        List<IBaseMessage> list = new List<IBaseMessage>();
        using (MemoryStream ms = new MemoryStream(buff))
        {
            using (BinaryReader buffers = new BinaryReader(ms, this.utf8))
            {
                try
                {
                    byte[] _buff;

                    while (true)
                    {
                        #region 包头读取  
                        //循环读取包头             
                        //判断本次解析的字节是否满足常量字节数   
                        if ((buffers.BaseStream.Length - buffers.BaseStream.Position) < ConstLenght)
                        {
                            _buff = buffers.ReadBytes((int)(buffers.BaseStream.Length - buffers.BaseStream.Position));
                            this._LBuff.AddRange(_buff);
                            return list;
                        }
                        byte tt1 = buffers.ReadByte();
                        byte tt2 = buffers.ReadByte();
                        byte tt3 = buffers.ReadByte();
                        byte tt4 = buffers.ReadByte();
                        if (!(tt1 == t1 && tt3 == t2))
                        {
                            Debug.LogErrorFormat("tt1 = {0},tt2 = {1}", tt1.ToString("x8"), tt2.ToString("x8"));
                            Debug.LogErrorFormat("tt3 = {0},tt4 = {1}",tt3.ToString("x8"),tt4.ToString("x8"));
                            long ttttt = buffers.BaseStream.Seek(-3, SeekOrigin.Current);
                            continue;
                        }
                        else
                        {
                            //Debug.LogErrorFormat("成功 包头！！！");
                        }
                        #endregion

                        #region 包协议  
                        int offset = buffers.ReadInt16();
                        //Debug.LogErrorFormat("包协议，长度是 offset={0}",offset);
                        #endregion

                        #region 包解析  
                        //剩余字节数大于本次需要读取的字节数  
                        if (offset <= (buffers.BaseStream.Length - buffers.BaseStream.Position))
                        {
                            int msgID = buffers.ReadInt32();
                            //Debug.LogErrorFormat("msgID= {0}",msgID);
                            _buff = buffers.ReadBytes(offset - 4);

                            IBaseMessage msg = ReceiverHelper.PopMessage();
                            msg.WriteIn(msgID, _buff, 0, _buff.Length);
                            list.Add(msg);
                            if ((buffers.BaseStream.Length - buffers.BaseStream.Position) > 0)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            //剩余字节数刚好小于本次读取的字节数 存起来，等待接受剩余字节数一起解析  
                            _buff = buffers.ReadBytes((int)(buffers.BaseStream.Length - buffers.BaseStream.Position + ConstLenght));
                            this._LBuff.AddRange(_buff);
                        }
                        #endregion

                        break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogErrorFormat("MarshalEndian Decode error: {0}", ex);
                }

            }
        }
        return list;
    }


}