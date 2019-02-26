using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Accounting.Computer.Lib
{
    public delegate void PrintMessage(string str);

    public delegate void ShowError(Exception ex);

    public struct ServiceEquipment
    {
        PrintMessage printMessage;

        ShowError showError;

        public void RegisterMessage(PrintMessage printMessage)
        {
            this.printMessage = printMessage;
        }

        public void RegisterError(ShowError showError)
        {
            this.showError = showError;
        }

        public string DBName { get; set; }

        public void AddEquipment(Software equipment)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Введи строку ублюдок");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Software>("Equipment");
                    equipments.Insert(equipment);
                }
                if (printMessage != null)
                    printMessage.Invoke("Всё окей рукожоп");
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
            }
        }

        public void EditEquipment(Software equipment)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("СВведи строку ублюдок");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Software>("Equipment");
                    equipments.Update(equipment);
                }
                if (printMessage != null)
                    printMessage.Invoke("Всё окей рукожоп");
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
            }
        }

        public void DelEquipment(int equipmentId)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Введи строку ублюдок");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Software>("Equipment");
                    equipments.Delete(equipmentId);
                }
                if (printMessage != null)
                    printMessage.Invoke("Запись удалена");
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
            }
        }

        public List<Software> SearchEquipment(string name)
        {
            List<Software> listEq = null;
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Введи строку ублюдок");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Software>("Equipment");
                    listEq = equipments.Find(x => x.Name.Equals(name)).ToList();
                }
                return listEq;
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
                return listEq;
            }
        }









    }
}
