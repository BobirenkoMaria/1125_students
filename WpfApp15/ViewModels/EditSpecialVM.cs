using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;
using WpfApp15.Pages;
using WpfApp15.Tools;

namespace WpfApp15.ViewModels
{
    public class EditSpecialVM : BaseVM
    {
        public Specials EditSpecial { get; }
        public CommandVM SaveSpecial { get; set; }
        public Group SpecialGroup
        {
            get => specialGroup;
            set
            {
                specialGroup = value;
                Signal();
            }
        }

        public List<Group> Groups { get; set; }

        private CurrentPageControl currentPageControl;
        private Group specialGroup;

        public EditSpecialVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditSpecial = new Specials();
            Init();
        }

        public EditSpecialVM(Specials editSpecial, CurrentPageControl currentPageControl)
        {
            EditSpecial = editSpecial;
            this.currentPageControl = currentPageControl;
            Init();
            //SpecialGroup = Groups.FirstOrDefault(s => s.ID == editSpecial.GroupId);
        }

        private void Init()
        {
            Groups = SqlModel.GetInstance().SelectGroupsRange(0, 100);
            SaveSpecial = new CommandVM(() => {
                //if (SpecialGroup == null)
                //{
                //    System.Windows.MessageBox.Show("Нужно выбрать группу для продолжения");
                //    return;
                //}
                //EditSpecial.GroupId = SpecialGroup.ID;
                var model = SqlModel.GetInstance();
                if (EditSpecial.ID == 0)
                    model.Insert(EditSpecial);
                else
                    model.Update(EditSpecial);
                currentPageControl.SetPage(new ViewSpecialsPage(SpecialGroup));
            });
        }

    }
}
