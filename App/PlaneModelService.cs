using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace App
{
    public class PlaneModelService
    {
        public void AddNewPlaneModel(PlaneModel planeModel)
        {
            using (var context = new SkySkannerContext())
            {
                context.PlaneModels.Add(planeModel);
                context.SaveChanges();
            }
        }
        public PlaneModel GetPlaneModelByName(string planeModelName)
        {
            PlaneModel planeModel = new PlaneModel();
            using (var context = new SkySkannerContext())
            {
                planeModel = context.PlaneModels.FirstOrDefault(x => x.Name.Equals(planeModelName));
            }
            return planeModel; //ten planeModel może być nullem, jeśli zostanie podany nieistniejący w bazie parametr planeModelName

        }
    }
}
