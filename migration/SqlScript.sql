CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
);
CREATE TABLE IF NOT EXISTS users(
  id MEDIUMINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_uid VARCHAR(64) NOT NULL,
  email VARCHAR(255) NOT NULL,
  name VARCHAR(32) NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  update_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);
ALTER TABLE
  users
ADD
  INDEX user_uid(user_uid);
CREATE TABLE IF NOT EXISTS teams(
    id MEDIUMINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    public_team_id VARCHAR(36) NOT NULL,
    name VARCHAR(32) NOT NULL,
    number INT NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    update_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
  );
ALTER TABLE
  teams
ADD
  INDEX public_team(public_team_id);
CREATE TABLE IF NOT EXISTS user_team_middles(
    user_id MEDIUMINT NOT NULL,
    team_id MEDIUMINT NOT NULL,
    status enum("LEADER", "MEMBER") NOT NULL DEFAULT "MEMBER",
    PRIMARY KEY(user_id, team_id),
    FOREIGN KEY(user_id) REFERENCES users(id),
    FOREIGN KEY(team_id) REFERENCES teams(id)
  );
CREATE TABLE IF NOT EXISTS team_objectives(
    id MEDIUMINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    public_objective_id VARCHAR(36) NOT NULL,
    team_id MEDIUMINT NOT NULL,
    use_date DATE NOT NULL,
    title VARCHAR(128) NOT NULL,
    content VARCHAR(225) NOT NULL,
    author VARCHAR(32) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    update_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(team_id) REFERENCES teams(id)
  );
ALTER TABLE
  team_objectives
ADD
  INDEX public_Tobjective(public_objective_id);
CREATE TABLE IF NOT EXISTS user_objectives(
    id MEDIUMINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    public_objective_id VARCHAR(36) NOT NULL,
    user_id MEDIUMINT NOT NULL,
    team_id MEDIUMINT NOT NULL,
    use_date TIMESTAMP NOT NULL,
    title VARCHAR(128) NOT NULL,
    content VARCHAR(225) NOT NULL,
    author VARCHAR(32) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    update_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(user_id) REFERENCES users(id),
    FOREIGN KEY(team_id) REFERENCES teams(id)
  );
ALTER TABLE
  user_objectives
ADD
  INDEX public_Uobjective(public_objective_id);