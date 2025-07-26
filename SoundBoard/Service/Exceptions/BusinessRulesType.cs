using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SoundBoard.Service.Exceptions
{
    /// <summary>
    /// Dictionnary of business rules
    /// </summary>
    public class BusinnessRulesDictionnary
    {
        public required List<BusinessRules> businessRules;
        public BusinnessRulesDictionnary()
        {
            businessRules = new List<BusinessRules>();
            DictionnaryInitialize();
        }
        /// <summary>
        /// Get a business rule by its code
        /// </summary>
        /// <param name="Code">The code of the business rule</param>
        /// <returns>The business rule found, or null if not found</returns>
        public BusinessRules GetBusinessRules(string Code)
        {
            return businessRules.FirstOrDefault(cd => cd.Code == Code);
        }

        /// <summary>
        /// Add a business rule
        /// </summary>
        /// <param name="dictionnary"></param>
        /// <param name="businessRules"></param>
        /// <returns></returns>
        public static BusinnessRulesDictionnary operator +(
            BusinnessRulesDictionnary dictionnary,
            BusinessRules businessRules
        )
        {
            dictionnary.businessRules.Add(businessRules);
            return dictionnary;
        }

        /// <summary>
        /// Remove a business rule
        /// </summary>
        /// <param name="dictionnary"></param>
        /// <param name="businessRules"></param>
        /// <returns></returns>
        public static BusinnessRulesDictionnary operator -(
            BusinnessRulesDictionnary dictionnary,
            BusinessRules businessRules
        )
        {
            dictionnary.businessRules.Remove(businessRules);
            return dictionnary;
        }

        /// <summary>
        /// initialize the dictionnary of business rules
        /// </summary>
        public void DictionnaryInitialize()
        {
           this.businessRules = businessRules + new BusinessRules( "1", "Business rule 1");

           this.businessRules = businessRules + new BusinessRules( "2", "Business rule 1");
        }
    }

    /// <summary>
    /// Business rule object
    /// </summary>
    public class BusinessRules
    {
        public BusinessRules(string code, string message) => (Code, Message) = (code, message);

        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        
          /// <summary>
        /// Add a business rule
        /// </summary>
        /// <param name="dictionnary"></param>
        /// <param name="businessRules"></param>
        /// <returns></returns>
        public static List<BusinessRules> operator +(
            List<BusinessRules> dictionnary,
            BusinessRules businessRules
        )
        {
            dictionnary.Add(businessRules);
            return dictionnary;
        }

        /// <summary>
        /// Remove a business rule
        /// </summary>
        /// <param name="dictionnary"></param>
        /// <param name="businessRules"></param>
        /// <returns></returns>
        public static List<BusinessRules> operator -(
           List<BusinessRules> dictionnary,
            BusinessRules businessRules
        )
        {
            dictionnary.Remove(businessRules);
            return dictionnary;
        }
    }
}
