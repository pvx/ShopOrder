using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using DevExpress.Utils.Serializing;
using DevExpress.Utils.Serializing.Helpers;
using DevExpress.XtraGrid.Views.Base;

namespace ShopOrderCustom
{
    public class GridLayoutSerializer : XmlXtraSerializer
    {
        public static void SaveLayout(ColumnView view, Stream stream)
        {
            var serializer = new GridLayoutSerializer();
            serializer.Serialize(stream, serializer.GetFilterProps(view), "View");
        }

        private XtraPropertyInfoCollection GetFilterProps(ColumnView view)
        {
            var store = new XtraPropertyInfoCollection();
            var propList = new ArrayList();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(view);
            propList.Add(properties.Find("Columns", false));
            propList.Add(properties.Find("OptionsView", false));
            propList.Add(properties.Find("ActiveFilterEnabled", false));
            propList.Add(properties.Find("ActiveFilterString", false));
            propList.Add(properties.Find("MRUFilters", false));
            propList.Add(properties.Find("ActiveFilter", false));

            MethodInfo mi = typeof (SerializeHelper).GetMethod("SerializeProperty",
                                                               BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo miGetXtraSerializableProperty = typeof (SerializeHelper).GetMethod(
                "GetXtraSerializableProperty", BindingFlags.NonPublic |
                                               BindingFlags.Instance);
            var helper = new SerializeHelper(view);
            (view as IXtraSerializable).OnStartSerializing();
            foreach (PropertyDescriptor prop in propList)
            {
                var newXtraSerializableProperty =
                    miGetXtraSerializableProperty.Invoke(helper, new object[] {view, prop})
                    as XtraSerializableProperty;
                var p = new SerializablePropertyDescriptorPair(prop, newXtraSerializableProperty);
                mi.Invoke(helper, new object[] {store, view, p, XtraSerializationFlags.None, null});
            }
            (view as IXtraSerializable).OnEndSerializing();
            return store;
        }
    }
}