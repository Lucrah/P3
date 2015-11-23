using Caliburn.Micro;
using P3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace i_hate_windows.Helpers
{
    class PDFConverter
    {
        //In charge of setting up a page, and filling the first couple of pages with the list of returned results, and the next couple of pages with graphs/calculations for the mægler ./ask rasmus
        //Basically, converting 2 objects, a) a list of returned results and b) an object consisting of the graphs output by the program, into pdf format.

        private string PDFPath;

        private BindableCollection<Listing> _searchResults;
        private object _graphResults;


        //Ctor, change this to take in rasmus's elements when they are done too
        public PDFConverter()
        {
            
        }

        [ImportingConstructor]
        public PDFConverter(IWindowManager windowManager, BindableCollection<Listing> searchResults, object graphResults)
        {
            _searchResults = searchResults;
            _graphResults = graphResults;
            PDFPath = GetPath();
        }

        //lets start by creating a path string to the pdf folder
        public string GetPath()
        {
            string yaypath;
            yaypath = Directory.GetCurrentDirectory();



            return yaypath;
        }

    }
}
