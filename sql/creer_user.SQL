-- -----------------------------------------------------------------------------
--             Génération d'une base de données pour
--                      Oracle Version 11g XE
--                        
-- -----------------------------------------------------------------------------
--      Projet : MaisonDesLigues
--      Auteur : Benoît ROCHE
--      Date de dernière modification : 9/01/2013 11:32:40
-- -----------------------------------------------------------------------------

-- -----------------------------------------------------------------------------
--      Partie 1: Création de l'utilisateur MDLEF qui sera aussi le propriétaire
-- 		des objets : tables, index, procédures
--		
--		Ce script doit être exécuté par un utilisateur possédant le droit de créer un utilisateur.
--		Par exemple l'utilisateur SYSTEM
-- -----------------------------------------------------------------------------
--
--      On commence par supprimer l'utilisateur avant de le recréer
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

