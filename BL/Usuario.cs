using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaPruebaEntities context = new DL.AAcostaPruebaEntities())
                {
                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Problema al Insertar";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaPruebaEntities context = new DL.AAcostaPruebaEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento);

                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Actualizo el Usuario";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }

        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaPruebaEntities context = new DL.AAcostaPruebaEntities())
                {
                    var query = context.UsuarioDelete(IdUsuario);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se elimino el usuario";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaPruebaEntities context = new DL.AAcostaPruebaEntities())
                {
                    var query = context.UsuarioGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString();

                            result.Objects.Add(usuario);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaPruebaEntities context = new DL.AAcostaPruebaEntities())
                {
                    var query = context.UsuarioGetById(IdUsuario).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString();
                        
                        result.Object = usuario;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception e)
            {
                result.Correct=false;
                result.Message = e.Message;
            }
            return result;
        }
    }
}