using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Payment.Fuiou.Paremetors
{
    internal class FuiouXml
    {

        #region Inner class
        internal class __XmlNode
        {
            public int Sort { get; set; }
            public string Node { get; set; }
            public string ElementName { get; set; }

            public __XmlNode(string elementName, string nodeText, int sort)
            {
                this.Sort = sort;
                this.ElementName = elementName;
                this.Node = string.Format("<{0}>{1}</{2}>", elementName, nodeText, elementName);

            }
        }
        #endregion

        #region Private Fields
        string _xmlTitle = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>";
        object _xmlData = null;
        List<__XmlNode> _appendNodes = new List<__XmlNode>();
        #endregion

        #region  Construction

        public FuiouXml(object xmlData) : this(string.Empty, xmlData) { }
        public FuiouXml(string title) : this(title, null) { }

        public FuiouXml(string title, object xmlData)
        {
            this._xmlTitle = title;
            this._xmlData = xmlData;
        }
        #endregion

        #region Public Method
        public void SetData(object objData)
        {
            _xmlData = objData;
        }
        public void AppendNode(string elementName, string value)
        {
            _appendNodes.Add(new __XmlNode(elementName, ifNullOrEmpty(value), _appendNodes.Count + 10000));
        }

        public string GetXml()
        {
            if (_xmlData != null)
            {
                var ap = _xmlData.GetType().GetCustomAttribute<ParemetorAttribute>();
                if (ap == null)
                    ap = new ParemetorAttribute(_xmlData.GetType().Name, 0);
                var element = new __XmlNode(ap.FieldName, convertObjToXml(_xmlData), 0);
                return element.Node;
            }
            return string.Empty;
        }
        #endregion

        #region Private Method
        private string convertObjToXml(object obj)
        {
            StringBuilder sb = new StringBuilder();
            var xmldata = getXmlElements(obj);
            foreach (var item in xmldata)
            {
                sb.Append(item.Node);
            }
            foreach (var item in _appendNodes)
            {
                sb.Append(item.Node);
            }
            return sb.ToString();
        }

        private List<__XmlNode> getXmlElements(object obj)
        {
            var ps = getObjProperties(obj);
            List<__XmlNode> _list = new List<__XmlNode>();
            foreach (var item in ps)
            {
                var cp = item.GetCustomAttribute<ParemetorAttribute>();
                _list.Add(new __XmlNode(cp.FieldName, ifNullOrEmpty(item.GetValue(obj)), cp.Sort));
            }
            return _list.OrderBy(p => p.Sort).ToList();
        }

        private string ifNullOrEmpty(object obj)
        {
            if (obj == null) return "";
            if (obj.ToString() == "") return "";
            return obj.ToString();
        }

        private PropertyInfo[] getObjProperties(object obj)
        {
            var t = obj.GetType();
            var props = t.GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => p.GetCustomAttributes(typeof(ParemetorAttribute), true)
                    .FirstOrDefault() != null)
                    .ToArray();
            if (props == null)
                props = new PropertyInfo[] { };
            return props;
        }
        #endregion
    }
}
