CREATE PROCEDURE dbo.GetModels
AS
	SELECT Model, ModelID, Model.MakeID, Make  FROM Model
	JOIN Make ON
	Make.MakeID = Model.MakeID