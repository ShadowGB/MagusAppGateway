using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.UI.ViewModel
{
    public class AuthenticationOptionsEditDto
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// APIScope名称
        /// </summary>
        [Display(Name = "APIScope名称")]
        public string AuthenticationProviderKey { get; set; }

        public Guid? RoutesGuid { get; set; }

        public RoutesEditDto Routes { get; set; }
    }
}
