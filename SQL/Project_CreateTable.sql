DROP SEQUENCE ship_sequence;

DROP TABLE reservation;
DROP TABLE cruise_destination;
DROP TABLE cruise;
DROP TABLE destination;
DROP TABLE traveller;

CREATE TABLE traveller
(
	id VARCHAR2(30)
		CONSTRAINT traveller_id_nn NOT NULL
		CONSTRAINT traveller_id_pk PRIMARY KEY,
	first_name VARCHAR2(40)
		CONSTRAINT traveller_first_name_nn NOT NULL,
	last_name VARCHAR2(40)
		CONSTRAINT traveller_last_name_nn NOT NULL,
	email VARCHAR2(30)
		CONSTRAINT traveller_email_nn NOT NULL,
	administrator NUMBER(1)
		CONSTRAINT traveller_is_admin_nn NOT NULL
		CONSTRAINT traveller_is_admin_ck CHECK (administrator IN (0, 1)) -- 1=administrator, 0=not administrator
);

-- Lookup Table
CREATE TABLE destination
(
	destination VARCHAR2(50)
		CONSTRAINT destination_destination_nn NOT NULL
		CONSTRAINT destination_destination_pk PRIMARY KEY
);

CREATE TABLE cruise
(
	ship_id NUMBER(3)
		CONSTRAINT ship_id_nn NOT NULL
		CONSTRAINT ship_id_ck CHECK(ship_id > 0)
		CONSTRAINT ship_id_pk PRIMARY KEY,
	ship_name VARCHAR2(40)
		CONSTRAINT ship_name_nn NOT NULL);

CREATE TABLE cruise_destination
(
	ship_id NUMBER(3)
		CONSTRAINT cdestination_ship_id_nn NOT NULL
		CONSTRAINT cdestination_ship_id_fk REFERENCES cruise(ship_id),
	destination VARCHAR2(40)
		CONSTRAINT cdestination_destination_nn NOT NULL
		CONSTRAINT cdestination_destination_fk REFERENCES destination(destination),
	CONSTRAINT cdestination_pk PRIMARY KEY(ship_id, destination)
);

CREATE TABLE reservation
(
	ship_id NUMBER(3)
		CONSTRAINT reservation_ship_id_nn NOT NULL
		CONSTRAINT reservation_ship_id_fk REFERENCES cruise(ship_id),
	cabin_no NUMBER(4)
		CONSTRAINT reservation_cabin_no_nn NOT NULL
		CONSTRAINT reservation_cabin_no_ck CHECK (cabin_no >= 1000),
	traveller_id VARCHAR2(30)
		CONSTRAINT reservation_traveller_id_nn NOT NULL
		CONSTRAINT reservation_traveller_id_fk REFERENCES traveller(id),
	CONSTRAINT reservation_ship_id_cabin_pk PRIMARY KEY(ship_id, cabin_no)
);

CREATE SEQUENCE ship_sequence;

-- When you insert your traveller account into the traveller, specify your user_id in upper case.  E.g.	
INSERT INTO traveller (id, first_name, last_name, email, administrator) VALUES ('OLS655_162A04', 'Wayne', 'Bryan', 'wayne.bryan@senecacollege.ca', 1);
COMMIT;

-- Some cruise ships have been provided for your convenience
INSERT INTO cruise(ship_id, ship_name) VALUES (ship_sequence.NEXTVAL, 'Sea Voyager');
INSERT INTO cruise(ship_id, ship_name) VALUES (ship_sequence.NEXTVAL, 'Wave Cracker');
INSERT INTO cruise(ship_id, ship_name) VALUES (ship_sequence.NEXTVAL, 'Wave Topper');
INSERT INTO cruise(ship_id, ship_name) VALUES (ship_sequence.NEXTVAL, 'Ocean Navigator');
INSERT INTO cruise(ship_id, ship_name) VALUES (ship_sequence.NEXTVAL, 'Friend of the Sea');
INSERT INTO cruise(ship_id, ship_name) VALUES (ship_sequence.NEXTVAL, 'Sea Companion');
INSERT INTO cruise(ship_id, ship_name) VALUES (ship_sequence.NEXTVAL, 'Ocean Skater');
INSERT INTO cruise(ship_id, ship_name) VALUES (ship_sequence.NEXTVAL, 'AquaGlider');
INSERT INTO cruise(ship_id, ship_name) VALUES (ship_sequence.NEXTVAL, 'Ocean Liner 7');
INSERT INTO cruise(ship_id, ship_name) VALUES (ship_sequence.NEXTVAL, 'Sea Hopper');
COMMIT;

INSERT INTO destination(destination) VALUES ('Jamaica');
INSERT INTO destination(destination) VALUES ('Saint Lucia');
INSERT INTO destination(destination) VALUES ('Hawaii');
INSERT INTO destination(destination) VALUES ('Italy');
INSERT INTO destination(destination) VALUES ('Turkey');
INSERT INTO destination(destination) VALUES ('Greece');
INSERT INTO destination(destination) VALUES ('Mexico');
INSERT INTO destination(destination) VALUES ('The Bahamas');
INSERT INTO destination(destination) VALUES ('Bermuda');
INSERT INTO destination(destination) VALUES ('Alaska');
COMMIT;