using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TextSpeaker.Model;

// ReSharper disable once CheckNamespace
namespace TextSpeaker.ViewModels.Tests
{
    [TestClass]
    public class TextSpeachPageViewModelTest
    {
        [TestMethod]
        public void SpeachTest()
        {
            var service = new Mock<ITextToSpeachService>();
            var viewModel = new TextSpeachPageViewModel(service.Object);
            viewModel.Text = "Message";
            viewModel.Speach();

            service.Verify(m => m.Speach("Message"));
        }
    }
}
