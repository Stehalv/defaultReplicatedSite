using DefaultReplicatedSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultReplicatedSite.Services
{
    public interface IFlow
    {
        CheckoutSteps CurrentStep { get; set; }
        List<CheckoutSteps> CheckoutStepList { get; }
        CheckoutFlowType Type { get; }
        CheckoutSteps PreviousStep { get; }
        CheckoutSteps NextStep { get; }
    }
}
