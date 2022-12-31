
CREATE PROCEDURE [dept].[list_departments]
AS
BEGIN
	SELECT *
	FROM dept.department
END
GO

CREATE PROCEDURE [dept].[list_professorByDept]
	@deptId INT
AS
BEGIN
	SELECT *
	FROM dept.professor 
	WHERE dept_id = @deptId;
END


