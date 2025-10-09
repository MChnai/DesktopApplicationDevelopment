using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY_PC634
{
	internal class Producer
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public string PhoneNum { get; set; }
		public Producer() { }
		public Producer(int iD, string name, string description, string address, string phoneNum)
		{
			ID = iD;
			Name = name;
			Description = description;
			Address = address;
			PhoneNum = phoneNum;
		}
		public override string ToString()
		{
			return ID + "," + Name + "," + Address + "," + Description + "," + PhoneNum;
		}
	}
}
