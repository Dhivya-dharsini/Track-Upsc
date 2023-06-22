using System;
using java.io;
using Microsoft.AspNetCore.Mvc;
using opennlp.tools.postag;
using opennlp.tools.tokenize;
using OpenNLP.Tools.PosTagger;
using TrackUPSC.Models;
using static opennlp.tools.formats.ad.ADSentenceStream;

namespace TrackUPSC.Controllers
{
	public class SearchController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public SearchController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public List<Question> SearchQuestions(string searchKeyword)
        {
            QuestionModel questionModel = HomeController.questionModel;

            List<Question> searchResults = new List<Question>();

            foreach (Question question in questionModel.questions)
            {
                if (ContainsImportantKeyword(question, searchKeyword))
                {
                    searchResults.Add(question);
                }
            }

            return searchResults;
        }

        private bool ContainsImportantKeyword(Question qn, string searchKeyword)
        {
            string[] words = qn.question.Split(' ');
            try
            {

               String modelPath="/Users/dhivya/Downloads/TrackUPSC/TrackUPSC/Resources/en-token.bin";
                java.io.FileInputStream tokenInputStream = new java.io.FileInputStream(modelPath);     //load the token model into a stream
                opennlp.tools.tokenize.TokenizerModel tokenModel = new opennlp.tools.tokenize.TokenizerModel(tokenInputStream); //load the token model
                opennlp.tools.tokenize.TokenizerME tokenizer= new opennlp.tools.tokenize.TokenizerME(tokenModel);  //create the tokenizer
                string[] tokens = tokenizer.tokenize(qn.question);


                FileInputStream posModelIn = new FileInputStream("/Users/dhivya/Downloads/TrackUPSC/TrackUPSC/Resources/en-pos-maxent.bin");
                POSModel posModel = new POSModel(posModelIn);
                POSTaggerME posTagger = new POSTaggerME(posModel);
                string[] tags = posTagger.tag(tokens);

                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];
                    string tag = tags[i];

                    if (!IsPronounOrVerb(tag) && word.ToLower() == searchKeyword.ToLower())
                    {
                        return true;
                    }
                }
            }catch(Exception e)
            {
                
            }
            return false;
        }

        private bool IsPronounOrVerb(string tag)
        {
            return tag.StartsWith("PRP") || tag.StartsWith("VB");
        }

    }
}

