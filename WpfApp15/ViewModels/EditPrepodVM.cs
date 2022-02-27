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
    public class EditPrepodVM : BaseVM
    {
        public Prepod EditPrepod { get; }
        public CommandVM SavePrepod { get; set; }
        public Group PrepodGroup
        {
            get => prepodGroup;
            set
            {
                prepodGroup = value;
                Signal();
            }
        }

        public List<Group> Groups { get; set; }

        private CurrentPageControl currentPageControl;
        private Group prepodGroup;

        public EditPrepodVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPrepod = new Prepod();
            Init();
        }

        public EditPrepodVM(Prepod editPrepod, CurrentPageControl currentPageControl)
        {
            EditPrepod = editPrepod;
            this.currentPageControl = currentPageControl;
            Init();
            //            CuratorGroup = Groups.FirstOrDefault(s => s.ID == editCurator.GroupId);
        }

        private void Init()
        {
            Groups = SqlModel.GetInstance().SelectGroupsRange(0, 100);
            SavePrepod = new CommandVM(() => {
                //if (CuratorGroup == null)
                //{
                //    System.Windows.MessageBox.Show("Нужно выбрать группу для продолжения");
                //    return;
                //}
                //                EditCurator.GroupId = CuratorGroup.ID;
                var model = SqlModel.GetInstance();
                if (EditPrepod.ID == 0)
                    model.Insert(EditPrepod);
                else
                    model.Update(EditPrepod);
                currentPageControl.SetPage(new ViewPrepodsPage(PrepodGroup));
            });
        }

    }
}
