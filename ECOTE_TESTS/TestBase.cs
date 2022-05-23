using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ECOTE_TESTS {
    public abstract class TestBase {
        private static string[] embeddedResourceNames;

        static TestBase() {
            embeddedResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        }

        protected string LoadTestCase(int number) {
            var assembly = Assembly.GetExecutingAssembly();
            var testCaseName = $"TestCase{number}.cpp";
            var resourceName = embeddedResourceNames.First(x => x.EndsWith(testCaseName));

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream, Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}
