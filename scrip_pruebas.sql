--Drops
DROP SCHEMA SELECTIONADOS;
DROP PROCEDURE [SELECTIONADOS].[01_Insert_Datos_Iniciales];
DROP PROCEDURE [SELECTIONADOS].[02_Migracion_De_Datos];
DROP PROCEDURE [SELECTIONADOS].[03_Creacion_De_Las_FK];
DROP PROCEDURE [SELECTIONADOS].[04_Usuarios];
DROP PROCEDURE [SELECTIONADOS].[SP_Update_Funionalidad_Por_Rol];
DROP PROCEDURE [SELECTIONADOS].[SP_Create_Rol];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Afiliado_By];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Estado_Civil];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Funcionalidades];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Funcionalidades_Rol];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Roles];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Usuario];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Usuario_Rol];
DROP PROCEDURE [SELECTIONADOS].[SP_Update_Afiliado];
DROP PROCEDURE [SELECTIONADOS].[SP_Update_Rol];
DROP PROCEDURE [SELECTIONADOS].[SP_Insert_Compra_Bono];
DROP PROCEDURE [SELECTIONADOS].[SP_Block_Usuario];
DROP PROCEDURE [SELECTIONADOS].[SP_Delete_Afiliado];
DROP PROCEDURE [SELECTIONADOS].[SP_GenerarTurno];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_AgendaProfesional];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_DisponibilidadProfesional];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Especialidad_Descripcion];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_EspecialidadMedicas];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_FamiliarACargo];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_IdAsociado_Usuario];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Planes];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Planes_PrecioBono];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Profesional_ByApellido];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Profesional_ByApellidoAndEspecialidad];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Profesional_ByEspecialidad];
DROP PROCEDURE [SELECTIONADOS].[SP_Get_Turnos_Today_ByProfesional];
DROP PROCEDURE [SELECTIONADOS].[SP_Insert_Disponibilidad_Profesional];
DROP PROCEDURE [SELECTIONADOS].[SP_Update_FamiliarACargo];
DROP TRIGGER [SELECTIONADOS].[Tr_Nro_Afiliado];
DROP TRIGGER [SELECTIONADOS].[Tr_Log_Baja_Afiliado];
DROP TRIGGER [SELECTIONADOS].[Tr_Bloqueo_Usuarios];
DROP TABLE [SELECTIONADOS].[Asignacion_Rol];
DROP TABLE [SELECTIONADOS].[Cancelacion];
DROP TABLE [SELECTIONADOS].[Afiliados];
DROP TABLE [SELECTIONADOS].[Planes];
DROP TABLE [SELECTIONADOS].[Estado_Civil];
DROP TABLE [SELECTIONADOS].[Turno];
DROP TABLE [SELECTIONADOS].[Log_Block_Usuario];
DROP TABLE [SELECTIONADOS].[Usuarios];
DROP TABLE [SELECTIONADOS].[Log_Baja_Afiliado];
DROP TABLE [SELECTIONADOS].[Log_Compra_Bono];
DROP TABLE [SELECTIONADOS].[Consulta];
DROP TABLE [SELECTIONADOS].[Bono_Afiliado];
DROP TABLE [SELECTIONADOS].[Familiar_ACargo];
DROP TABLE [SELECTIONADOS].[Rol_X_Funcionalidad];
DROP TABLE [SELECTIONADOS].[Rol];
DROP TABLE [SELECTIONADOS].[Funcionalidades];
DROP TABLE [SELECTIONADOS].[Disp_Profesional];
DROP TABLE [SELECTIONADOS].[Profesional_Especialidad];
DROP TABLE [SELECTIONADOS].[Especialidad];
DROP TABLE [SELECTIONADOS].[Profesional];
DROP TABLE [SELECTIONADOS].[Tipo_Especialidad];

SELECT Consulta.Nro_Consulta, Turno.Nro_Afiliado FROM SELECTIONADOS.Consulta
  INNER JOIN SELECTIONADOS.Turno
  ON Consulta.Nro_Turno = Turno.Nro_Turno
  INNER JOIN SELECTIONADOS.Profesional
  ON Turno.ID_Profesional = Profesional.ID_Profesional
WHERE Consulta.Realizada = 0 AND Profesional.ID_Profesional = 1

SELECT * FROM SELECTIONADOS.Consulta WHERE Nro_Consulta = 30002

UPDATE SELECTIONADOS.Consulta SET Enfermedades = NULL , Sintomas = NULL , Fecha_DeLaConsulta = NULL , Realizada = 0
WHERE Nro_Consulta = 30002

UPDATE SELECTIONADOS.Consulta SET Enfermedades = 'a' , Sintomas = 's' , Fecha_DeLaConsulta = '2016-11-24 12:16:00' , Realizada = 0
WHERE Nro_Consulta = 30002

UPDATE SELECTIONADOS.Consulta SET Enfermedades = @enfermedad, Sintomas = @sintomas, Fecha_DeLaConsulta = @fecha_consulta, Realizada = 1
    WHERE Nro_Consulta = @nroConsulta