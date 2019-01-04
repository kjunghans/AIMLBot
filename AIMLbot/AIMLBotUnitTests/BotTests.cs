using System;
using Xunit;
using AIMLbot;
using System.IO;
using System.Xml;

namespace AIMLbot.UnitTests
{
    public class BotTests
    {
        private AIMLbot.Bot mockBot;

        private string binaryGraphmasterFileName = "Graphmaster.dat";

        private string pathToCustomTagDll = Path.GetFullPath(@"./AIMLbot.Example.CustomTags.dll");

        [Fact]
        public void testLoadSettings()
        {
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings();
            Assert.True(this.mockBot.GlobalSettings.containsSettingCalled("aimldirectory"));
            Assert.True(this.mockBot.GlobalSettings.containsSettingCalled("feelings"));
            Assert.Equal("", this.mockBot.AdminEmail);
            Assert.True(this.mockBot.TrustAIML);
            Assert.Equal(256, this.mockBot.MaxThatSize);
            Assert.Equal(AIMLbot.Utils.Gender.Unknown, this.mockBot.Sex);
            Assert.True(this.mockBot.GenderSubstitutions.containsSettingCalled(" HE "));
            Assert.True(this.mockBot.Person2Substitutions.containsSettingCalled(" YOUR "));
            Assert.True(this.mockBot.PersonSubstitutions.containsSettingCalled(" MYSELF "));
            Assert.True(this.mockBot.DefaultPredicates.containsSettingCalled("we"));
        }

        [Fact]
        public void testLoadSettingsWithPath()
        {
            string pathToSettings = Path.Combine(Environment.CurrentDirectory,Path.Combine("configAlt","SettingsAlt.xml"));
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings(pathToSettings);
            Assert.True(this.mockBot.GlobalSettings.containsSettingCalled("aimldirectory"));
            Assert.True(this.mockBot.GlobalSettings.containsSettingCalled("feelings"));
            Assert.Equal("test@test.com", this.mockBot.AdminEmail);
            Assert.Equal(AIMLbot.Utils.Gender.Unknown, this.mockBot.Sex);
            Assert.True(this.mockBot.GenderSubstitutions.containsSettingCalled(" HE "));
            Assert.True(this.mockBot.Person2Substitutions.containsSettingCalled(" YOUR "));
            Assert.True(this.mockBot.PersonSubstitutions.containsSettingCalled(" MYSELF "));
            Assert.True(this.mockBot.DefaultPredicates.containsSettingCalled("we"));
        }

        [Fact]
        public void testLoadSettingsWithEmptyArg()
        {
            // Other tests for loading settings are covered in the generic SettingsDictionaryTests.cs file
            this.mockBot = new AIMLbot.Bot();
            Action act = () => this.mockBot.loadSettings("");
            Assert.Throws<FileNotFoundException>(act);
        }

        [Fact]
        public void testSplittersSetUpFromBadData()
        {
            string pathToSettings = Path.Combine(Environment.CurrentDirectory, Path.Combine("configAlt", "SettingsAltBad.xml"));
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings(pathToSettings);
            Assert.Equal(4, this.mockBot.Splitters.Count);
        }

        [Fact]
        public void testAttributesAreOKWithGoodData()
        {
            string pathToSettings = Path.Combine(Environment.CurrentDirectory, Path.Combine("configAlt", "SettingsAlt.xml"));
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings(pathToSettings);
            Assert.Equal("test@test.com", this.mockBot.AdminEmail);
            Assert.True(this.mockBot.IsLogging);
            System.Globalization.CultureInfo mockCIObj = new System.Globalization.CultureInfo("en-GB");
            Assert.Equal(this.mockBot.Locale.EnglishName, mockCIObj.EnglishName);
            Assert.Equal(this.mockBot.PathToAIML, Path.Combine(Environment.CurrentDirectory, "aiml"));
            Assert.Equal(this.mockBot.PathToConfigFiles, Path.Combine(Environment.CurrentDirectory, "configAlt"));
            Assert.Equal(this.mockBot.PathToLogs, Path.Combine(Environment.CurrentDirectory, "logs"));
            Assert.Equal(AIMLbot.Utils.Gender.Unknown, this.mockBot.Sex);
            Assert.Equal(2000, this.mockBot.TimeOut);
            Assert.Equal("OOPS: The request has timed out.", this.mockBot.TimeOutMessage);
            Assert.True(this.mockBot.WillCallHome);
            Assert.Equal(5, this.mockBot.Splitters.Count);
        }

        [Fact]
        public void testAttributesAreSetupAfterBadData()
        {
            string pathToSettings = Path.Combine(Environment.CurrentDirectory, Path.Combine("configAlt", "SettingsAltBad.xml"));
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings(pathToSettings);
            Assert.Equal("", this.mockBot.AdminEmail);
            Assert.False(this.mockBot.IsLogging);
            System.Globalization.CultureInfo mockCIObj = new System.Globalization.CultureInfo("en-US");
            Assert.Equal(this.mockBot.Locale.EnglishName, mockCIObj.EnglishName);
            Assert.Equal(this.mockBot.PathToAIML, Path.Combine(Environment.CurrentDirectory, "aiml"));
            Assert.Equal(this.mockBot.PathToConfigFiles, Path.Combine(Environment.CurrentDirectory, "config"));
            Assert.Equal(this.mockBot.PathToLogs, Path.Combine(Environment.CurrentDirectory, "logs"));
            Assert.Equal(AIMLbot.Utils.Gender.Unknown, this.mockBot.Sex);
            Assert.Equal(2000, this.mockBot.TimeOut);
            Assert.Equal("ERROR: The request has timed out.", this.mockBot.TimeOutMessage);
            Assert.False(this.mockBot.WillCallHome);
        }

        [Fact]
        public void testAdminEmailValidationSingleName()
        {
            this.mockBot = new AIMLbot.Bot();
            Action act = () => this.mockBot.AdminEmail="joe";
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void testAdminEmailValidationTLDTooShort()
        {
            this.mockBot = new AIMLbot.Bot();
            Action act = () => this.mockBot.AdminEmail="joe@home";
            Assert.Throws<Exception>(act);

        }

        [Fact]
        public void testAdminEmailValidationAllElementsTooShort()
        {
            this.mockBot = new AIMLbot.Bot();
            Action act = () => this.mockBot.AdminEmail="a@b.c";
            Assert.Throws<Exception>(act);

        }

        [Fact]
        public void testAdminEmailValidationGood()
        {
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.AdminEmail="joe@home.com";
            Assert.Equal("joe@home.com",this.mockBot.AdminEmail);
        }

        [Fact]
        public void testAdminEmailValidationGoodDotDelineatedName()
        {
            this.mockBot=new AIMLbot.Bot();
            this.mockBot.AdminEmail="joe.bloggs@home.com";
            Assert.Equal("joe.bloggs@home.com",this.mockBot.AdminEmail);
        }

        [Fact]
        public void testAdminEmailValidationBadATSign()
        {
            this.mockBot = new AIMLbot.Bot();
            Action act = () => this.mockBot.AdminEmail="joe-bloggs[at]home.com";
            Assert.Throws<Exception>(act);

        }

        [Fact]
        public void testAdminEmailValidationGoodDotDelineatedTLD()
        {
            this.mockBot=new AIMLbot.Bot();
            this.mockBot.AdminEmail="joe@his.home.com";
            Assert.Equal("joe@his.home.com",this.mockBot.AdminEmail);
        }

        [Fact]
        public void testAdminEmailValidationBadSpareDotAtEndName()
        {
            this.mockBot = new AIMLbot.Bot();
            Action act = () => this.mockBot.AdminEmail="joe.@bloggs.com";
            Assert.Throws<Exception>(act);

        }

        [Fact]
        public void testAdminEmailValidationBadSpareDotAtStartName()
        {
            this.mockBot = new AIMLbot.Bot();
            Action act = () => this.mockBot.AdminEmail=".joe@bloggs.com";
            Assert.Throws<Exception>(act);

        }

        [Fact]
        public void testAdminEmailValidationIllegalCharsInName()
        {
            this.mockBot = new AIMLbot.Bot();
            Action act = () => this.mockBot.AdminEmail="joe<>bloggs@bloggs.come";
            Assert.Throws<Exception>(act);

        }

        [Fact]
        public void testAdminEmailValidationAmpersand()
        {
            this.mockBot=new AIMLbot.Bot();
            this.mockBot.AdminEmail="joe&bloggs@bloggs.com";
            Assert.Equal("joe&bloggs@bloggs.com",this.mockBot.AdminEmail);
        }

        [Fact]
        public void testAdminEmailValidationTilde()
        {
            this.mockBot=new AIMLbot.Bot();
            this.mockBot.AdminEmail="~joe@bloggs.com";
            Assert.Equal("~joe@bloggs.com",this.mockBot.AdminEmail);
        }

        [Fact]
        public void testAdminEmailValidationDollar()
        {
            this.mockBot=new AIMLbot.Bot();
            this.mockBot.AdminEmail="joe$@bloggs.com";
            Assert.Equal("joe$@bloggs.com",this.mockBot.AdminEmail);
        }

        [Fact]
        public void testAdminEmailValidationPlus()
        {
            this.mockBot=new AIMLbot.Bot();
            this.mockBot.AdminEmail="joe+bloggs@bloggs.com";
            Assert.Equal("joe+bloggs@bloggs.com",this.mockBot.AdminEmail);
        }

        [Fact]
        public void testAdminEmailValidationApostrophe()
        {
            this.mockBot=new AIMLbot.Bot();
            this.mockBot.AdminEmail="o'reilly@there.com";
            Assert.Equal("o'reilly@there.com",this.mockBot.AdminEmail);
        }

        [Fact]
        public void testBotLogging()
        {
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings();
            this.mockBot.GlobalSettings.addSetting("maxlogbuffersize", "3");
            this.mockBot.GlobalSettings.addSetting("islogging", "true");

            string logFilePath = Path.Combine(this.mockBot.PathToLogs, DateTime.Now.ToString("yyyyMMdd") + ".log");
            FileInfo fiLogFile = new FileInfo(logFilePath);
            if (fiLogFile.Exists)
            {
                // remove the file if left over from prior tests
                fiLogFile.Delete();
            }

            this.mockBot.writeToLog("test1");
            this.mockBot.writeToLog("test2");
            this.mockBot.writeToLog("test3");
            fiLogFile = new FileInfo(logFilePath);
            Assert.True(fiLogFile.Exists);
            long filesize = fiLogFile.Length;
            this.mockBot.writeToLog("test4");
            this.mockBot.writeToLog("test5");
            this.mockBot.writeToLog("test6");
            fiLogFile.Refresh();
            Assert.True((fiLogFile.Length>filesize));
        }

        [Fact]
        public void testLoadFromAIML()
        {
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            //Assert.Equal(AIMLTagHandlers.sizeTagTests.Size, this.mockBot.Size);
        }

        [Fact]
        public void testSimpleChat()
        {
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            Result output = this.mockBot.Chat("bye", "1");
            Assert.Equal("Cheerio.", output.RawOutput);
        }

        [Fact]
        public void testTimeOutChatWorks()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            Result output = this.mockBot.Chat("infiniteloop1", "1");
            Assert.True(output.request.hasTimedOut);
            Assert.Equal("ERROR: The request has timed out.", output.Output);
        }

        [Fact]
        public void testChatRepsonseWhenNotAcceptingInput()
        {
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            this.mockBot.isAcceptingUserInput = false;
            Result output = this.mockBot.Chat("Hi", "1");
            Assert.Equal("This bot is currently set to not accept user input.", output.Output);
        }

        [Fact]
        public void testSaveSerialization()
        {
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            FileInfo fi = new FileInfo(this.binaryGraphmasterFileName);
            if (fi.Exists)
            {
                fi.Delete();
            }
            this.mockBot.saveToBinaryFile(this.binaryGraphmasterFileName);
            FileInfo fiCheck = new FileInfo(this.binaryGraphmasterFileName);
            Assert.True(fiCheck.Exists);
        }

        [Fact]
        public void testLoadFromBinary()
        {
            testSaveSerialization();
            this.mockBot = new AIMLbot.Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadFromBinaryFile(this.binaryGraphmasterFileName);
            Result output = this.mockBot.Chat("bye", "1");
            Assert.Equal("Cheerio.", output.RawOutput);
        }

        [Fact]
        public void testCustomTagGoodData()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            FileInfo fi = new FileInfo(this.pathToCustomTagDll);
            Assert.True(fi.Exists);
            this.mockBot.loadCustomTagHandlers(this.pathToCustomTagDll);
            Result output = this.mockBot.Chat("test custom tag", "1");
            Assert.Equal("Test tag works! inner text is here.", output.RawOutput);
        }

        [Fact]
        public void testCustomTagOverride()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            FileInfo fi = new FileInfo(this.pathToCustomTagDll);
            Assert.True(fi.Exists);
            this.mockBot.loadCustomTagHandlers(this.pathToCustomTagDll);
            Result output = this.mockBot.Chat("test custom tag override", "1");
            Assert.Equal("Override default tag implementation works correctly.", output.RawOutput);
        }

        [Fact]
        public void testCustomTagsMultipleInstances()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            AIMLbot.User mockUser = new User("1", this.mockBot);
            AIMLbot.Request mockRequest = new Request("Pig latin",mockUser,this.mockBot);
            AIMLbot.Result mockResult = new Result(mockUser,this.mockBot,mockRequest);
            AIMLbot.Utils.SubQuery mockSubquery = new AIMLbot.Utils.SubQuery("PIG LATIN <that> * <topic> *");
            FileInfo fi = new FileInfo(this.pathToCustomTagDll);
            Assert.True(fi.Exists);
            this.mockBot.loadCustomTagHandlers(this.pathToCustomTagDll);

            XmlNode pigLatin1 = AIMLbot.Utils.AIMLTagHandler.getNode("<piglatin>(All the world is a stage!)</piglatin>");
            XmlNode pigLatin2 = AIMLbot.Utils.AIMLTagHandler.getNode("<piglatin>(All the world is still a stage!)</piglatin>");

            AIMLbot.Utils.AIMLTagHandler taghandler1 = this.mockBot.getBespokeTags(mockUser, mockSubquery, mockRequest, mockResult, pigLatin1);
            AIMLbot.Utils.AIMLTagHandler taghandler2 = this.mockBot.getBespokeTags(mockUser, mockSubquery, mockRequest, mockResult, pigLatin2);

            Assert.Equal("(Allway ethay orldway isway away agestay!)",taghandler1.Transform());
            Assert.Equal("(Allway ethay orldway isway illstay away agestay!)", taghandler2.Transform());
        }

        [Fact]
        public void testCustomTagBadFile()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            var absolutePath = Path.GetFullPath(@"./doesnotexist.dll");
            Action act = () => this.mockBot.loadCustomTagHandlers(absolutePath);
            Assert.Throws<FileNotFoundException>(act);
        }

        [Fact]
        public void TestCustomTagNotFoundInLoadedDll()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            FileInfo fi = new FileInfo(this.pathToCustomTagDll);
            Assert.True(fi.Exists);
            this.mockBot.loadCustomTagHandlers(this.pathToCustomTagDll);
            Result output = this.mockBot.Chat("test missing custom tag", "1");
            Assert.Equal("The inner text of the missing tag.", output.RawOutput);
        }

        [Fact]
        public void testCustomTagAccessToWebService()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            FileInfo fi = new FileInfo(this.pathToCustomTagDll);
            Assert.True(fi.Exists);
            this.mockBot.loadCustomTagHandlers(this.pathToCustomTagDll);
            Result output = this.mockBot.Chat("what is my fortune", "1");
            Assert.True(output.RawOutput.Length > 0);
        }

        [Fact]
        public void testCustomTagAccessToRSSFeed()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            FileInfo fi = new FileInfo(this.pathToCustomTagDll);
            Assert.True(fi.Exists);
            this.mockBot.loadCustomTagHandlers(this.pathToCustomTagDll);
            Result output = this.mockBot.Chat("Test news tag", "1");
            string result = output.RawOutput.Replace("[[BBC News]]", "");
            Assert.True(result.Length > 0);
        }

        [Fact]
        public void testCustomTagAccessToRssFeedWithArguments()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            FileInfo fi = new FileInfo(this.pathToCustomTagDll);
            Assert.True(fi.Exists);
            this.mockBot.loadCustomTagHandlers(this.pathToCustomTagDll);
            Result output = this.mockBot.Chat("Test news tag with descriptions", "1");
            string result = output.RawOutput.Replace("[[BBC News]]", "");
            Assert.True(result.Length > 0);
        }

        [Fact]
        public void testCustomTagDuplicationException()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            FileInfo fi = new FileInfo(this.pathToCustomTagDll);
            Assert.True(fi.Exists);
            this.mockBot.loadCustomTagHandlers(this.pathToCustomTagDll);
            Action act = () => this.mockBot.loadCustomTagHandlers(this.pathToCustomTagDll);
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void testCustomTagPigLatin()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            FileInfo fi = new FileInfo(this.pathToCustomTagDll);
            Assert.True(fi.Exists);
            this.mockBot.loadCustomTagHandlers(this.pathToCustomTagDll);
            Result output = this.mockBot.Chat("Test pig latin", "1");
            Assert.Equal("(Allway ethay orldway isway away agestay!).",output.Output);
        }

        [Fact]
        public void testWildCardsDontMixBetweenSentences()
        {
            this.mockBot = new Bot();
            this.mockBot.loadSettings();
            this.mockBot.loadAIMLFromFiles();
            Result output = this.mockBot.Chat("My name is FIRST. My name is SECOND.","1");
            Assert.Equal("Hello FIRST! Hello SECOND!", output.Output);
        }
    }
}
