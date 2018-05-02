DECLARE success NUMBER;
BEGIN
  create_reservation(2, 2345, 'ols655_162a08', success);
  dbms_output.put_line(success);
END;