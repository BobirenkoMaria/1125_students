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
    public class EditDisciplineVM : BaseVM
    {
        public Discipline EditDiscipline { get; }
        public CommandVM SaveDiscipline { get; set; }
        public Group DisciplineGroup
        {
            get => disciplineGroup;
            set
            {
                disciplineGroup = value;
                Signal();
            }
        }

        public List<Group> Groups { get; set; }

        private CurrentPageControl currentPageControl;
        private Group disciplineGroup;

        public EditDisciplineVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditDiscipline = new Discipline();
            Init();
        }

        public EditDisciplineVM(Discipline editDiscipline, CurrentPageControl currentPageControl)
        {
            EditDiscipline = editDiscipline;
            this.currentPageControl = currentPageControl;
            Init();
            //            CuratorGroup = Groups.FirstOrDefault(s => s.ID == editCurator.GroupId);
        }

        private void Init()
        {
            Groups = SqlModel.GetInstance().SelectGroupsRange(0, 100);
            SaveDiscipline = new CommandVM(() => {
                //if (CuratorGroup == null)
                //{
                //    System.Windows.MessageBox.Show("Нужно выбрать группу для продолжения");
                //    return;
                //}
                //                EditCurator.GroupId = CuratorGroup.ID;
                var model = SqlModel.GetInstance();
                if (EditDiscipline.ID == 0)
                    model.Insert(EditDiscipline);
                else
                    model.Update(EditDiscipline);
                currentPageControl.SetPage(new ViewDisciplinesPage(DisciplineGroup));
            });
        }

    }
}
