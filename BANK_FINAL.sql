CREATE TABLE system_profile (
    id_profile INT NOT NULL,
    username VARCHAR2(50) UNIQUE NOT NULL,
    password_profile VARCHAR2(50) NOT NULL,
    id_role_type int not null
);

CREATE TABLE status_account (
    id_status INT NOT NULL,
    status VARCHAR2(50) UNIQUE NOT NULL
);

ALTER TABLE status_account ADD PRIMARY KEY (id_profile);
ALTER TABLE system_profile ADD CONSTRAINT profile_role_FK FOREIGN KEY(id_role_type) REFERENCES profile_role(id_role_type); 
alter table employee add id_profile int;
ALTER TABLE employee ADD CONSTRAINT cemployee_id_profile_fk FOREIGN KEY(id_profile) REFERENCES system_profile(id_profile); 
alter table account add
create table profile_role (
    id_role_type int not null,
    type_role varchar(15)
    );
alter table profile_role add primary key (id_role_type);


CREATE SEQUENCE Profile_role_seq START WITH 1 NOCACHE ORDER ;
CREATE OR REPLACE TRIGGER profile_role_seq
BEFORE INSERT ON profile_role
FOR EACH ROW
WHEN (NEW.id_role_type IS NULL)
BEGIN :NEW.id_role_type := Profile_role_seq.NEXTVAL;
END;

INSERT INTO profile_role(type_role) VALUES('client');

CREATE SEQUENCE Profile_seq START WITH 1 NOCACHE ORDER ;
CREATE OR REPLACE TRIGGER Profile_seq
BEFORE INSERT ON system_profile
FOR EACH ROW
WHEN (NEW.id_profile IS NULL)
BEGIN :NEW.id_profile := profile_seq.NEXTVAL;
END;

INSERT INTO system_profile(username,password_profile,id_role_type) VALUES('siyana@abv.bg','123456','1');


CREATE OR REPLACE PROCEDURE profile_role_pro
(v_pos_type profile_role.type_role%TYPE)
AS
 BEGIN
 INSERT INTO profile_role(type_role)
 VALUES (v_pos_type);
 END;

BEGIN 
profile_role_pro('employee');
END;


CREATE OR REPLACE PROCEDURE system_profile_pro
(v_pos_username system_profile.username%TYPE,
v_pos_password system_profile.password_profile%type,
v_pos_id_role_type system_profile.id_role_type%type)
AS
 BEGIN
 INSERT INTO system_profile(username,password_profile, id_role_type)
 VALUES (v_pos_username, v_pos_password, v_pos_id_role_type);
 END;

CREATE SEQUENCE system_profile_seq START WITH 2 INCREMENT BY 1;

CREATE OR REPLACE PROCEDURE insert_system_profile (
    p_username IN VARCHAR2,
    p_password_profile IN VARCHAR2,
    p_id_role_type IN INT
)
AS
BEGIN
    INSERT INTO system_profile (username, password_profile, id_role_type)
    VALUES (p_username, p_password_profile, p_id_role_type);
END;



CREATE OR REPLACE PROCEDURE update_system_profile (
    p_id_profile IN INT,
    p_username IN VARCHAR2,
    p_password_profile IN VARCHAR2,
    p_id_role_type IN INT
)
AS
BEGIN
    UPDATE system_profile
    SET username = p_username,
        password_profile = p_password_profile,
        id_role_type = p_id_role_type
    WHERE id_profile = p_id_profile;
END;


ALTER TABLE account
ADD CONSTRAINT account_status_fk
FOREIGN KEY (id_status_account)
REFERENCES status_account(id_status);