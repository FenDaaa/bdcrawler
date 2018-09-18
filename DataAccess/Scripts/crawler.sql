DROP DATABASE IF EXISTS `crawler`;
CREATE DATABASE `crawler`;
USE `crawler`;

-- Table article
DROP TABLE IF EXISTS `article`;
CREATE TABLE `article` (
  `Url` varchar(1024) NOT NULL COMMENT 'article url',
  `SiteName` varchar(32) NOT NULL COMMENT 'site name',
  `Title` varchar(256) COMMENT 'article title',
  `Content` mediumtext COMMENT 'article html content',
  `Category` varchar(128) DEFAULT NULL COMMENT 'article category',
  `IndexCode` varchar(64) DEFAULT NULL COMMENT 'article index code',
  `IssueCode` varchar(64) DEFAULT NULL COMMENT 'article issue code',
  `PublishAgency` varchar(512) DEFAULT NULL COMMENT 'article publish agency',
  `PublishDate` datetime DEFAULT NULL COMMENT 'article publish date',
  `Keyword` varchar(128) DEFAULT NULL COMMENT 'article keyword',
  `CrawledDate` datetime DEFAULT NULL COMMENT 'crawled date',
  `IsShow` int COMMENT 'is show',
  `IsCenter` int COMMENT 'is center',
  PRIMARY KEY (`Url`),
  UNIQUE KEY `Url_UNIQUE` (`Url`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='article table';

-- Table article attachment
DROP TABLE IF EXISTS `articleattachment`;
CREATE TABLE `articleattachment` (
  `ArticleUrl` varchar(1024) NOT NULL COMMENT 'article url',
  `AttachmentName` varchar(512) NOT NULL COMMENT 'attachement name',
  `SourceUrl` varchar(1024) NOT NULL COMMENT 'attachement source url',
  `FileContent` longblob NOT NULL COMMENT 'attachment file content',
  `CrawledDate` datetime DEFAULT NULL COMMENT 'crawled date',
  PRIMARY KEY (`SourceUrl`),
  KEY `Url_idx` (`ArticleUrl`),
  CONSTRAINT `ArtilcleRelation` FOREIGN KEY (`ArticleUrl`) REFERENCES `article` (`Url`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='article attachment table';

-- Table crawler log
DROP TABLE IF EXISTS `crawlerlog`;
CREATE TABLE `crawlerlog` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Url` varchar(1024) NOT NULL COMMENT 'fail url',
  `Message` text COMMENT 'fail message',
  `LogTime` datetime DEFAULT NULL COMMENT 'log time',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COMMENT='crawler log';

CREATE TABLE `articlemonitor` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SiteName` varchar(32) NOT NULL,
  `SiteUrl` varchar(1024) NOT NULL,
  `Status` int(11) NOT NULL,
  `StartTime` datetime NOT NULL,
  `EndTime` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8 COMMENT='article monitor';