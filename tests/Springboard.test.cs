using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using SpringBoard.Tests.Models;

[TestFixture]
public class SpringBoardTests: PageTest
{
    public required SpringBoardHomePage springBoardPage;
    

    [SetUp]
    public async Task Setup()
    {
        springBoardPage = new SpringBoardHomePage(Page);
        await springBoardPage.OpenUrl();
    }

    [Test]
    public async Task OpenSpringBoardHomePage()
    {
        await Expect(springBoardPage.GetPage()).ToHaveTitleAsync(new Regex("Springboard: Online Courses"));
    }

    [Test]
    public async Task OpenLoginPage()
    {
        await springBoardPage._loginButton.ClickAsync();

        await Expect(springBoardPage._emailTextBox).ToBeVisibleAsync();
        await Expect(springBoardPage._passwordTextBox).ToBeVisibleAsync();
    }

    [Test]
    public async Task FacebookLoginPage()
    {
        await springBoardPage.GetPage().ScreenshotAsync(new () {
            Path = "tests/screenshot.png",
            FullPage = true,
        });
        await springBoardPage._loginButton.ClickAsync();
        await springBoardPage._facebookLoginButton.ClickAsync();

        await Expect(springBoardPage.GetPage()).ToHaveURLAsync(new Regex("fb-login-update"));
    }

    [Test]
    public async Task GoogleLoginPage()
    {
        await springBoardPage.GetPage().ScreenshotAsync(new () {
            Path = "tests/screenshot.png",
            FullPage = true,
        });
        await springBoardPage._loginButton.ClickAsync();
        await springBoardPage._googleLoginButton.ClickAsync();

        await Expect(springBoardPage.GetPage()).ToHaveURLAsync(new Regex("accounts.google.com"));
    }

    [Test]
    public async Task LinkedinLoginPage()
    {
        await springBoardPage.GetPage().ScreenshotAsync(new () {
            Path = "tests/screenshot.png",
            FullPage = true,
        });
        await springBoardPage._loginButton.ClickAsync();
        await springBoardPage._linkedlnLoginButton.ClickAsync();

        await Expect(springBoardPage.GetPage()).ToHaveURLAsync(new Regex("www.linkedin.com"));
    }


    [Test]
    public async Task VerifyBlogPage()
    {
        var blogPage = await springBoardPage.ClickBlogLink();
        
        await Expect(blogPage._emailTextBox).ToBeVisibleAsync();
        await Expect(blogPage._suscribeButton).ToBeVisibleAsync();
    }
}