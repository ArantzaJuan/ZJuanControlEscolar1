using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   
        public class Materia
        {
        public static ML.Result Getall()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities1 contex = new DL.ZJuanControlEscolarEntities1())
                {

                    var materias = contex.MateriaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (materias != null)
                    {
                        foreach (var obj in materias)
                        {

                            ML.Materia materiaobj = new ML.Materia();

                            materiaobj.idMateria = obj.idMateria;
                            materiaobj.nombre = obj.nombre;
                            materiaobj.costo =byte.Parse( obj.costo.ToString());
                            
                            result.Objects.Add(materiaobj);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "los usuarios no se pudo mostar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }
        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities1 contex = new DL.ZJuanControlEscolarEntities1())
                {

                    var materias = contex.MateriaGetById(idMateria).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (materias != null)
                    {
                         ML.Materia materiaobj = new ML.Materia();

                            materiaobj.idMateria = materias.idMateria;
                            materiaobj.nombre = materias.nombre;
                            materiaobj.costo = byte.Parse(materias.costo.ToString());

                            result.Objects.Add(materiaobj);
                        
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "los usuarios no se pudo mostar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }
        public static ML.Result Add(ML.Materia materia)
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (DL.ZJuanControlEscolarEntities1 contex = new DL.ZJuanControlEscolarEntities1())
                    {
                        var query = contex.MateriaAdd(materia.nombre, materia.costo);
                        if (query > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se ingreso el registro";
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                    result.Ex = ex;
                }
                return result;


            }
        public static ML.Result UpDate(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities1 contex = new DL.ZJuanControlEscolarEntities1())
                {
                    var query = contex.MateriaUpDate(materia.nombre, materia.costo,materia.idMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;


        }
        public static ML.Result Delete(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities1 contex = new DL.ZJuanControlEscolarEntities1())
                {
                    var query = contex.MateriaDElete(idMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;


        }
    }
    
}
