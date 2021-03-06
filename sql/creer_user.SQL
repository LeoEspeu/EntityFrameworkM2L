-- -----------------------------------------------------------------------------
--             G�n�ration d'une base de donn�es pour
--                      Oracle Version 11g XE
--                        
-- -----------------------------------------------------------------------------
--      Projet : MaisonDesLigues
--      Auteur : Beno�t ROCHE
--      Date de derni�re modification : 9/01/2013 11:32:40
-- -----------------------------------------------------------------------------

-- -----------------------------------------------------------------------------
--      Partie 1: Cr�ation de l'utilisateur MDLEF qui sera aussi le propri�taire
-- 		des objets : tables, index, proc�dures
--		
--		Ce script doit �tre ex�cut� par un utilisateur poss�dant le droit de cr�er un utilisateur.
--		Par exemple l'utilisateur SYSTEM
-- -----------------------------------------------------------------------------
--
--      On commence par supprimer l'utilisateur avant de le recr�er
-- -
-- 
drop user MDLEF cascade ;
create user mdlef identified by mdlef 
DEFAULT TABLESPACE USERS
TEMPORARY TABLESPACE TEMP
ACCOUNT UNLOCK ;

-- Droits ... il faudra en rajouter certainement
GRANT RESOURCE,CONNECT TO MDLEF;
grant create view to mdlef;
grant create public synonym to mdlef;
grant drop public synonym to mdlef;

-- SYSTEM PRIVILEGES

-- QUOTAS
ALTER USER MDLEF QUOTA UNLIMITED ON USERS;

