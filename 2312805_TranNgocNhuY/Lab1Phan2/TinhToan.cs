using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2312805_TranNgocNhuY.Lab1Phan2
{
	internal class TinhToan
	{
		public int CongHaiSo(int a, int b)
		{
			return a + b;
		}
		public int TongDaySo(int n)
		{
			int sum = 0;
			for (int i = 1; i <= n; i++)
				sum += i;
			return sum;
		}
	}
}
