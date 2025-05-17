using System;
using System.Windows.Forms;

namespace GreenByte.Models
{
    public class DeviceEvent
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }

        // Özellik adlarını veritabanı sütun adlarıyla eşleştirin
        public string islem { get; set; } // veritabanındaki sütun adını kullanın
        public string tetikleyici { get; set; } // veritabanındaki sütun adını kullanın

        public DateTime Time { get; set; }
        public string Status { get; set; } = "";
        public string Description { get; set; } = "";
        public string DeviceName { get; set; } = "";

        // Yardımcı özellikler (bunlar artık deserialization sırasında kullanılmıyor)
        [System.ComponentModel.Browsable(false)]
        public System.Action Action { get; set; } = new System.Action(() => { });

        [System.ComponentModel.Browsable(false)]
        public System.Type TriggerEvent { get; set; } = typeof(object);

        // İşlem adını almak için yardımcı metot
        public string GetActionName()
        {
            if (int.TryParse(islem, out int actionValue))
            {
                switch (actionValue)
                {
                    case 0: return "Bilgi";
                    case 1: return "Uyari";
                    case 2: return "Hata";
                    case 3: return "Kritik";
                    case 4: return "Basari";
                    case 5: return "Baslatildi";
                    case 6: return "Durdu";
                    default: return "Bilinmeyen";
                }
            }
            return islem ?? "Bilinmeyen";
        }

        // Tetikleyici tipini almak için yardımcı metot
        public string GetTriggerEventName()
        {
            if (int.TryParse(tetikleyici, out int triggerValue))
            {
                return triggerValue == 0 ? "Manuel" : "Otomatik";
            }
            return tetikleyici ?? "Bilinmeyen";
        }

        // Renk seçimi için yardımcı metot
        public System.Drawing.Color GetRowColor()
        {
            if (int.TryParse(islem, out int actionValue))
            {
                switch (actionValue)
                {
                    case 1: // Uyari
                        return System.Drawing.Color.LightYellow;
                    case 2: // Hata
                    case 3: // Kritik
                        return System.Drawing.Color.LightPink;
                    case 4: // Basari
                    case 5: // Baslatildi
                        return System.Drawing.Color.LightGreen;
                    default:
                        return System.Drawing.Color.White;
                }
            }
            return System.Drawing.Color.White;
        }
    }
}