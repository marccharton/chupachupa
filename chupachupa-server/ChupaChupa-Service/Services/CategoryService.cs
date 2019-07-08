using ChupaChupa.Business.Controller;
using ChupaChupa.Business.Database.DAO;
using ChupaChupa.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Service.Services
{
    class CategoryService : AbstractService
    {
        public IList<Message.Category> getCategories(Int64 userId)
        {
            this.findUserOrRaiseFaultException(userId, Resources.GetCategoryUserUnknwon);

            IList<Message.Category> ret = new List<Message.Category>();
            Tool.MessageMapper<Message.Category, Entities.Category> mapper = new Tool.MessageMapper<Message.Category, Category>();
            
            if (_user.Categories != null) {
                foreach (Category c in _user.Categories) {
                    ret.Add(mapper.map(c));
                }
            }
            return ret;
        }

        public Message.Category getCategoryById(Int64 userId, Int64 categoryId)
        {
            this.findUserOrRaiseFaultException(userId, Resources.GetCategoryUserUnknwon);

            if (_user.Categories == null) {
                throw new FaultException(Resources.GetCategoryUnknwonCategory);
            }

            Category category = _user.Categories.FirstOrDefault(c => c.IdEntity == categoryId);
            if (category == null) {
                throw new FaultException(Resources.GetCategoryUnknwonCategory);
            }

            Tool.MessageMapper<Message.Category, Entities.Category> mapper = new Tool.MessageMapper<Message.Category, Category>();
            return mapper.map(category);
        }


        public Message.Category addCategory(Int64 userId, string categoryName)
        {
            Tool.ToolBox.controlStringNotEmptyWithFaultException(categoryName, Resources.AddCategoryEmptyName);

            this.findUserOrRaiseFaultException(userId, Resources.AddCategoryUserUnknown);

            if (_user.Categories == null) {
                _user.Categories = new List<Category>();
            }

            Category category = _user.Categories.FirstOrDefault(c => categoryName.CompareTo(c.Name) == 0);

            if (category != null) {
                throw new FaultException(Resources.AddCategoryAlreadyOwned);
            }

            category = new Category() { Name = categoryName };
            CategoryController controller = new CategoryController();
            if (!controller.controlData(category)) {
                throw new FaultException(Resources.AddCategoryInvalidProperty);
            }

            _user.addCategory(category);

            this.saveUserOrRaiseFaultException(Resources.AddCategoryDatabaseErrror);

            Tool.MessageMapper<Message.Category, Entities.Category> mapper = new Tool.MessageMapper<Message.Category, Category>();
            return mapper.map(category);
        }

        public void dropCategory(Int64 userId, Int64 categoryId)
        {
            this.findUserOrRaiseFaultException(userId, Resources.DropCategoryUserUnknown);
            
            if (_user.Categories == null) {
                return;
            }

            Category category = _user.Categories.FirstOrDefault(c => c.IdEntity == categoryId);
            if (category != null) {
                CategoryDAO categorieDao = new CategoryDAO();
                if (!categorieDao.delete(category)) {
                    throw new FaultException(Resources.DropCategoryDatabaseError);
                }
            }
        }

        public void dropCategory(Int64 userId, string name) 
        {
            Tool.ToolBox.controlStringNotEmptyWithFaultException(name, Resources.DropCategoryEmptyName);

            this.findUserOrRaiseFaultException(userId, Resources.DropCategoryUserUnknown);

            if (_user.Categories == null) {
                return;
            }

            Category category = _user.Categories.FirstOrDefault(c => name.CompareTo(c.Name) == 0);
            if (category != null) {
                _user.Categories.Remove(category);
                CategoryDAO categorieDao = new CategoryDAO();
                if (!categorieDao.delete(category)) {
                    throw new FaultException(Resources.DropCategoryDatabaseError);
                }
            }
        }

        public void renameCategory(Int64 userId, Int64 categoryId, string newName) 
        {
            Tool.ToolBox.controlStringNotEmptyWithFaultException(newName, Resources.RenameCategoryEmptyName);

            this.findUserOrRaiseFaultException(userId, Resources.RenameCategoryUnknownUser);
            
            if (_user.Categories == null) {
                return;
            }

            Category category = _user.Categories.FirstOrDefault(c => c.IdEntity == categoryId);

            if (category == null) {
                throw new FaultException(Resources.RenameCategoryCategoryNotOwned);
            }

            if (_user.Categories.FirstOrDefault(c => newName.CompareTo(c.Name) == 0 && category.IdEntity != c.IdEntity) != null) {
                throw new FaultException(Resources.RenameCategoryAlreadyExist);
            }

            category.Name = newName;
            CategoryController controller = new CategoryController();
            if (!controller.controlData(category)) {
                throw new FaultException(Resources.RenameCategoryInvalidProperty);
            }

            this.saveUserOrRaiseFaultException(Resources.RenameCategoryDatabaseError);
        }
    }
}
