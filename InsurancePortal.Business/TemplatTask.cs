using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePortal.Business.Interfaces;
using InsurancePortal.Transport;
using InsurancePortal.Data;

namespace InsurancePortal.Business
{
    public class TemplatTask : ITemplate
    {
        public bool SetTemplate(TemplateViewModel model)
        {
            try
            {
                using (InsurancePortalEntities db = new InsurancePortalEntities())
                {
                    Template obj = db.Templates.Where(x => x.TemplateID == model.TemplateID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.TemplateName = model.TemplateName;
                        obj.ModifiedOn = DateTime.Now;
                        db.SaveChanges();
                    }
                    else
                    {
                        var temp = db.Templates.Select(x => x.TemplateID).Max();
                        obj.TemplateID = 1;
                        if (temp > 0)
                        {
                            obj.TemplateID = Convert.ToInt32(temp) + 1;
                        }
                        obj.TemplateName = model.TemplateName;
                        obj.CreatedOn = DateTime.Now;
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (EntryPointNotFoundException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DelTemplate(int TemplateID)
        {
            try
            {
                using (InsurancePortalEntities db = new InsurancePortalEntities())
                {
                    Template obj = db.Templates.Where(x => x.TemplateID == TemplateID).FirstOrDefault();
                    if (obj != null)
                    {
                        db.Templates.Remove(obj);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (EntryPointNotFoundException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<TemplateViewModel> GetTemplate()
        {
            List<TemplateViewModel> templist = new List<TemplateViewModel>();
            try
            {
                using (InsurancePortalEntities _context = new InsurancePortalEntities())
                {
                    List<Template> list = _context.Templates.ToList();
                    if (list != null && list.Count > 0)
                    {
                        templist = list.Select(x => new TemplateViewModel
                        {
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn,
                            TemplateID = x.TemplateID,
                            TemplateName = x.TemplateName,
                        }).ToList();
                    }
                }
            }
            catch (EntryPointNotFoundException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return templist;
        }
    }
}
