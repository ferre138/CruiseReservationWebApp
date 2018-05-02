SET SERVEROUTPUT ON SIZE 4000

/* This stored procedure checks if there already exists a 
reservation for the specified cruise ship and cabin number and if so, 
returns 0 through the psuccess OUT parameter to indicate that the 
reservation cannot be made (cabin is already reserved). 
Otherwise the procedure adds a reservation for the specified traveller 
to the database for the specified cruise ship and cabin number and 
returns 1 through the psuccess OUT parameter to indicate reservation 
was successfully made.

*/

CREATE OR REPLACE PROCEDURE create_reservation
(
	pship_id IN NUMBER,
	pcabin_no IN NUMBER,
	ptraveller_id IN VARCHAR2,	
	psuccess OUT NUMBER
)
IS
	num_reservs INTEGER;
BEGIN
	-- Check if the department name and location already exist and, if not, create it
	SELECT COUNT(*)
		INTO num_reservs
		FROM reservation
		WHERE ship_id = pship_id AND cabin_no = pcabin_no;
	
	IF num_reservs = 0 THEN
		INSERT INTO reservation (ship_id, cabin_no, traveller_id)
			VALUES (pship_id, pcabin_no, ptraveller_id);
		psuccess := 1;
	ELSE
		psuccess := 0;
	END IF;

/*
Note that we could commit in the stored procedure, but it is often better to leave the commit to the calling code
	COMMIT;
EXCEPTION
	WHEN OTHERS THEN
		ROLLBACK;
*/
END;
/

show errors