using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DefaultReplicatedSite.Models;

namespace DefaultReplicatedSite.Services
{
    public static class PropertyBagService
    {

        public static T Get<T>(string description) where T : IPropertyBag
        {
            // Attempt to load the bag from the cookie
            var cookie = HttpContext.Current.Session[description];
            if (cookie == null)
            {
                return Create<T>(description);
            }
            try
            {
                // Deserialize the session data and get our bag.
                dynamic bag = HttpContext.Current.Session[description];

                // If the customer ID in the bag doesn't match the current customer ID, stop here.
                if (!bag.IsValid())
                {
                    return Create<T>(description);
                }

                // If we got here, we have a valid property bag. Populate it into the current object.
                return bag;
            }
            catch
            {
                return Create<T>(description);
            }
        }
        public static T Create<T>(string description) where T : IPropertyBag
        {
            dynamic bag = Activator.CreateInstance(typeof(T));

            bag.SessionID = HttpContext.Current.Server.UrlEncode(Guid.NewGuid().ToString());
            bag.Description = description;
            bag.CreatedDate = DateTime.Now;
            bag = bag.OnBeforeUpdate(bag);

            Update<T>(bag);

            return bag;
        }
        public static T Update<T>(T propertyBag) where T : IPropertyBag
        {

            // Set the cookie
            HttpContext.Current.Session[propertyBag.Description] = propertyBag;


            return propertyBag;
        }
        public static T Delete<T>(T propertyBag) where T : IPropertyBag
        {
            var bag = Create<T>(propertyBag.Description);
            return bag;
        }
    }
}