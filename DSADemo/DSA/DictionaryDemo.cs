using System;


namespace DSADemo.DSA
{
    internal class DictionaryDemo
    {

        Dictionary<string, string> dic = new Dictionary<string, string>();
        public string PrintDictionary(string key)
        {


            InitialiseDictionary();

            if (dic.ContainsKey(key))
            {
                return dic[key];
            }

            return "NA";

        }

        private void InitialiseDictionary()
        {



            dic.Add("en", "english");
            dic.Add("tel", "telugu");
            dic.Add("hi", "hindi");
            dic.Add("sans", "sanskrit");

        }

    }
}
