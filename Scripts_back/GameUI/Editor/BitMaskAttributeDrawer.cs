using UnityEngine;
using System.Collections;
// 引入Editor命名空间  
using UnityEditor;

// 使用绘制器，如果使用了[EnumFlagsAttribute]的这种自定义特性  
// 就执行下面代码对EnumFlagsAttribute进行补充  
[CustomPropertyDrawer(typeof(BitMaskAttribute))]
public class EnumFlagsAttributeDrawer : PropertyDrawer
{

    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _lable)
    {
        // attribute 是PropertyAttribute类中的一个属性  
        // EnumFlagsAttribute中的所有属性都可以调用  
        BitMaskAttribute flags = attribute as BitMaskAttribute;
        // 枚举值的数值最后为一个数字，如果要取得其代表的或包含的数值必须通过按位运算来提取  
        // 绘制出一个下拉菜单，枚举类型  
        _property.intValue = EditorGUI.MaskField(_position, _property.displayName + "(" +_property.intValue+ ")", _property.intValue, _property.enumDisplayNames);
    }

}