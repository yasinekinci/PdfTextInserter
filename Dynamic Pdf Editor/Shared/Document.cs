using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Pdf_Editor.Shared
{
	public class Document
	{
        public byte[] Data { get; set; }
        public string TextValue { get; set; }
        public int XCoordinate { get; set; }
		public int YCoordinate { get; set; }
		public int PageNumber { get; set; }	

	}
}
