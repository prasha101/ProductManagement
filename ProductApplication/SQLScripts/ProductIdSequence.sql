CREATE SEQUENCE ProductIdSequence
    START WITH 100000  -- Start from 100000 to guarantee a 6-digit ID
    INCREMENT BY 1
    MINVALUE 100000;

	SELECT NEXT VALUE FOR ProductIdSequence