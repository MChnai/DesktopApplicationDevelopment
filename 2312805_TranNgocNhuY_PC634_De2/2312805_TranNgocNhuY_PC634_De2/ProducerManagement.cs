using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_PC634
{
	internal class ProducerManagement
	{
		public List<Producer> list;
		public ProducerManagement()
		{
			list = new List<Producer>();
		}
		//public void Read_Json(string path)
		//{
		//	StreamReader streamReader = new StreamReader(path);
		//	string json = streamReader.ReadToEnd();
		//	var array = (JObject)JsonConvert
		//}
		public void Add(Producer producer)
		{
			list.Add(producer);
		}
		public void Save_To_File(string filename)
		{
			StreamWriter streamWriter = new StreamWriter(filename);
			foreach(Producer producer in list)
			{
				streamWriter.WriteLine(producer.ToString());
			}
			streamWriter.Close();
		}
		public void Read_TXT(string path)
		{
			string t;
			string[] s;
			Producer producer;
			using(StreamReader sr = new StreamReader(path))
			{
				while((t=sr.ReadLine()) != null)
				{
					s = t.Split(',');
					producer = new Producer();
					producer.ID = Convert.ToInt32(s[0]);
					producer.Name = s[1];
					producer.Description = s[4];
					producer.Address = s[2];
					producer.PhoneNum = s[3];
					Add(producer);
				}
				sr.Close();
			}
		}
		public List<Producer> Find_Name(string name)
		{
			List<Producer> result = new List<Producer>();
			foreach(Producer producer in list)
			{
				if(producer.Name.Contains(name))
					result.Add(producer);
			}
			return result;
		}
		public List<Producer> Find_Phone(string phone)
		{
			List<Producer> result = new List<Producer>();
			foreach (Producer producer in list)
			{
				if (producer.PhoneNum.Contains(phone))
					result.Add(producer);
			}
			return result;
		}
	}
}
