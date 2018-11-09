// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: ProtoFile/MsgHeartbeat.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ProtobufMsg {

  /// <summary>Holder for reflection information generated from ProtoFile/MsgHeartbeat.proto</summary>
  public static partial class MsgHeartbeatReflection {

    #region Descriptor
    /// <summary>File descriptor for ProtoFile/MsgHeartbeat.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MsgHeartbeatReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChxQcm90b0ZpbGUvTXNnSGVhcnRiZWF0LnByb3RvEgtwcm90b2J1Zk1zZyJd",
            "CgxNc2dIZWFydEJlYXQSEAoIYWN0aW9uSWQYASABKAUSCwoDbnVtGAIgASgF",
            "EgoKAnQwGAMgASgDEgoKAnQxGAQgASgDEgoKAnQyGAUgASgDEgoKAnQzGAYg",
            "ASgDYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtobufMsg.MsgHeartBeat), global::ProtobufMsg.MsgHeartBeat.Parser, new[]{ "ActionId", "Num", "T0", "T1", "T2", "T3" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class MsgHeartBeat : pb::IMessage<MsgHeartBeat> {
    private static readonly pb::MessageParser<MsgHeartBeat> _parser = new pb::MessageParser<MsgHeartBeat>(() => new MsgHeartBeat());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MsgHeartBeat> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ProtobufMsg.MsgHeartbeatReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MsgHeartBeat() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MsgHeartBeat(MsgHeartBeat other) : this() {
      actionId_ = other.actionId_;
      num_ = other.num_;
      t0_ = other.t0_;
      t1_ = other.t1_;
      t2_ = other.t2_;
      t3_ = other.t3_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MsgHeartBeat Clone() {
      return new MsgHeartBeat(this);
    }

    /// <summary>Field number for the "actionId" field.</summary>
    public const int ActionIdFieldNumber = 1;
    private int actionId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ActionId {
      get { return actionId_; }
      set {
        actionId_ = value;
      }
    }

    /// <summary>Field number for the "num" field.</summary>
    public const int NumFieldNumber = 2;
    private int num_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Num {
      get { return num_; }
      set {
        num_ = value;
      }
    }

    /// <summary>Field number for the "t0" field.</summary>
    public const int T0FieldNumber = 3;
    private long t0_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long T0 {
      get { return t0_; }
      set {
        t0_ = value;
      }
    }

    /// <summary>Field number for the "t1" field.</summary>
    public const int T1FieldNumber = 4;
    private long t1_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long T1 {
      get { return t1_; }
      set {
        t1_ = value;
      }
    }

    /// <summary>Field number for the "t2" field.</summary>
    public const int T2FieldNumber = 5;
    private long t2_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long T2 {
      get { return t2_; }
      set {
        t2_ = value;
      }
    }

    /// <summary>Field number for the "t3" field.</summary>
    public const int T3FieldNumber = 6;
    private long t3_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long T3 {
      get { return t3_; }
      set {
        t3_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MsgHeartBeat);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MsgHeartBeat other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ActionId != other.ActionId) return false;
      if (Num != other.Num) return false;
      if (T0 != other.T0) return false;
      if (T1 != other.T1) return false;
      if (T2 != other.T2) return false;
      if (T3 != other.T3) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ActionId != 0) hash ^= ActionId.GetHashCode();
      if (Num != 0) hash ^= Num.GetHashCode();
      if (T0 != 0L) hash ^= T0.GetHashCode();
      if (T1 != 0L) hash ^= T1.GetHashCode();
      if (T2 != 0L) hash ^= T2.GetHashCode();
      if (T3 != 0L) hash ^= T3.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ActionId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ActionId);
      }
      if (Num != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Num);
      }
      if (T0 != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(T0);
      }
      if (T1 != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(T1);
      }
      if (T2 != 0L) {
        output.WriteRawTag(40);
        output.WriteInt64(T2);
      }
      if (T3 != 0L) {
        output.WriteRawTag(48);
        output.WriteInt64(T3);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ActionId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ActionId);
      }
      if (Num != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Num);
      }
      if (T0 != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(T0);
      }
      if (T1 != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(T1);
      }
      if (T2 != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(T2);
      }
      if (T3 != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(T3);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(MsgHeartBeat other) {
      if (other == null) {
        return;
      }
      if (other.ActionId != 0) {
        ActionId = other.ActionId;
      }
      if (other.Num != 0) {
        Num = other.Num;
      }
      if (other.T0 != 0L) {
        T0 = other.T0;
      }
      if (other.T1 != 0L) {
        T1 = other.T1;
      }
      if (other.T2 != 0L) {
        T2 = other.T2;
      }
      if (other.T3 != 0L) {
        T3 = other.T3;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            ActionId = input.ReadInt32();
            break;
          }
          case 16: {
            Num = input.ReadInt32();
            break;
          }
          case 24: {
            T0 = input.ReadInt64();
            break;
          }
          case 32: {
            T1 = input.ReadInt64();
            break;
          }
          case 40: {
            T2 = input.ReadInt64();
            break;
          }
          case 48: {
            T3 = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code