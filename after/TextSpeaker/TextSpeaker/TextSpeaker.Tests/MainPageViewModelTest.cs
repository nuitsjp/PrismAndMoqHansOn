// <copyright file="MainPageViewModelTest.cs">Copyright ©  2016</copyright>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using Prism.Services;
using TextSpeaker.ViewModels;

// ReSharper disable once CheckNamespace
namespace TextSpeaker.ViewModels.Tests
{
    [TestClass]
    public class MainPageViewModelTest
    {
        [TestMethod]
        public void WhenCancelWasSelectedInAlertDialog()
        {
            Mock<INavigationService> navigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> pageDialogService = new Mock<IPageDialogService>();

            var viewModel = new MainPageViewModel(navigationService.Object, pageDialogService.Object);

            var command = viewModel.NavigationCommand;
            Assert.IsNotNull(command);
            Assert.IsTrue(command.CanExecute(null));

            pageDialogService
                .Setup(m => m.DisplayAlertAsync("確認", "Text Speach画面へ遷移しますか？", "OK", "Cancel"))
                .Returns(Task.Run(() => false));
            command.Execute(null);
            pageDialogService.Verify(m => m.DisplayAlertAsync("確認", "Text Speach画面へ遷移しますか？", "OK", "Cancel"), Times.Once);

            navigationService.Verify(m => m.NavigateAsync("TextSpeachPage", It.IsAny<NavigationParameters>(), It.IsAny<bool?>(), It.IsAny<bool>()), Times.Never);
        }

        [TestMethod]
        public void WhenOkWasSelectedInAlertDialog()
        {
            Mock<INavigationService> navigationService = new Mock<INavigationService>();
            Mock<IPageDialogService> pageDialogService = new Mock<IPageDialogService>();

            var viewModel = new MainPageViewModel(navigationService.Object, pageDialogService.Object);

            var command = viewModel.NavigationCommand;
            Assert.IsNotNull(command);
            Assert.IsTrue(command.CanExecute(null));

            pageDialogService
                .Setup(m => m.DisplayAlertAsync("確認", "Text Speach画面へ遷移しますか？", "OK", "Cancel"))
                .Returns(Task.Run(() => true));
            command.Execute(null);
            pageDialogService.Verify(m => m.DisplayAlertAsync("確認", "Text Speach画面へ遷移しますか？", "OK", "Cancel"), Times.Once);

            navigationService.Verify(m => m.NavigateAsync("TextSpeachPage", It.IsAny<NavigationParameters>(), It.IsAny<bool?>(), It.IsAny<bool>()), Times.Once);
        }
    }
}
