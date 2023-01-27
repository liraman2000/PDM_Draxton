using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Blazor.Models.Sample;
using PDM_Draxton.Services;
using PDM_Draxton.Data;
using PDM_Draxton.Models;

namespace PDM_Draxton.Pages
{
    public partial class EditUserComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IdentityInformation _identity { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SampleService Sample { get; set; }



        public IEnumerable<PDM_Draxton.Models.Negocio> INegocio;
        public IEnumerable<PDM_Draxton.Models.Perfil> IRol;

        [Parameter]
        public dynamic Id { get; set; }
        public string IdNegocio { get; set; }

        public int IdRol { get; set; }

        public  bool deshabilita = false;

        PDM_Draxton.Models.Usuario _usuario;
        protected PDM_Draxton.Models.Usuario usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                if (!object.Equals(_usuario, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "usuario", NewValue = value, OldValue = _usuario };
                    _usuario = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {

            usuario = new PDM_Draxton.Models.Usuario() { };
            

            DataAccess da = new DataAccess();

            if (da.cons_Negocio(out List<PDM_Draxton.Models.Negocio> negTmp, out String msgErrorNeg))
            {
                INegocio = negTmp;
               
            }

            if (da.cons_Perfil(out List<PDM_Draxton.Models.Perfil> negRol, out msgErrorNeg))
            {
                IRol = negRol;

            }

            if (da.cons_Usuario(Id,out Usuario user, out String msgError))
            {
                usuario = user;
                IdNegocio = user.OrgId.ToString();
                IdRol = user.IdRol;
             //   usuario.IdUsuario = _identity.IdUsuario;

                if (IdRol == 2)
                    deshabilita = false;
                else
                {
                    IdNegocio = "0";
                    deshabilita = true;
                }
            }

            //var sampleGetOrderByIdResult = await Sample.GetOrderById(id:Id);
            //usuario = sampleGetOrderByIdResult;
        }

        protected void perfil()
        {
            if (IdRol == 2)
                deshabilita = false;
            else
            {
                IdNegocio = "0";
                deshabilita = true;
                usuario.OrgId = Convert.ToInt32(IdNegocio);
            }

            usuario.IdRol = IdRol;            

        }

        protected void negocio()
        {
          usuario.OrgId = Convert.ToInt32(IdNegocio);
        }
    protected async System.Threading.Tasks.Task Form0Submit(PDM_Draxton.Models.Usuario args)
        {
            try
            {
                DataAccess da = new DataAccess();

                if (args.Nombre == null)
                {

                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Nombre es requerido" });
                    return;
                }


                if (args.Correo == null)
                {

                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Correo es requerido" });
                    return;
                }

                if (args.Correo != String.Empty)
                {
                    char x = '@';
                    if (!args.Correo.Contains(x))
                    {
                        NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Correo es incorrecto" });
                        return;
                    }
                }


                if (args.IdRol == 0)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Seleccione un Perfil" });
                    return;
                }
                //if ((args.IdNegocio == da.cons_NegocioTodos() || args.IdNegocio == 0) && args.IdRol == 2)
                //{
                //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Seleccione un Negocio" });
                //    return;
                //}
              

                if (da.ins_Usuario(usuario, out String msgErrorNeg))
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Exito", Detail = $"Se actualizó el Usuario" });

                }
                DialogService.Close(this);
            }
            catch (System.Exception sampleCreateOrderException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to create new Order!" });
            }
            //try
            //{
            //   // var sampleUpdateOrderResult = await Sample.UpdateOrder(id:Id, order:order);
            //    DialogService.Close(usuario);
            //}
            //catch (System.Exception sampleUpdateOrderException)
            //{
            //    NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Order" });
            //}
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
