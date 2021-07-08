using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlueSample
{
    public class SimItem
    {
        [DisplayName("작업자명")]
        public string WorkerName { get; set; }
        [DisplayName("작업자ID")]
        public string WorkerID { get; set; }
        [DisplayName("주문ID")]
        public string OrderID { get; set; }
        [DisplayName("주문이름")]
        public string OrderName { get; set; }
        [DisplayName("아이템ID")]
        public string ItemID { get; set; }
        [DisplayName("아이템이름")]
        public string ItemName { get; set; }
        [DisplayName("프로세스ID")]
        public string ProcessID { get; set; }
        [DisplayName("프로세스이름")]
        public string ProcessName { get; set; }
        [DisplayName("시작시간")]
        public string StartTime { get; set; }
        [DisplayName("종료시간")]
        public string EndTime { get; set; }
        [DisplayName("장비ID")]
        public string EquipmentID { get; set; }
        [DisplayName("장비이름")]
        public string EquipmentName { get; set; }
        [DisplayName("공정종류")]
        public string ProcessKind { get; set; }
        [DisplayName("분할종류")]
        public string DivideKind { get; set; }
        [DisplayName("비고")]
        public string Remark { get; set; }
    }
}
