﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using GalaSoft.MvvmLight;
using _02350Demo.Model;

namespace _02350Demo.ViewModel
{
    public class EdgeViewModel : ViewModelBase
    {
        public EdgeViewModel(ClassBoxViewModel source, ClassBoxViewModel sink)
        {
            edge = new Edge();
            sink.connectedEdges.Add(this);
            source.connectedEdges.Add(this);
            Sink = sink.classBox;
            Source = source.classBox;
        }


        public Point SourcePoint
        {
            get { return edge.FindPreferedPoints().Item1; }
        }

        public Point SinkPoint
        {
            get { return edge.FindPreferedPoints().Item2; }
        }

        public void positionChanged()
        {
            RaisePropertyChanged(() => SourcePoint);
            RaisePropertyChanged(() => SinkPoint);
        }


        public Edge edge { get; }
    
        public bool isSelected { get; set; }

        public ClassBox Source
        {
            get { return edge.Source; }
            set { edge.Source = value; RaisePropertyChanged(() => Source); }
        }

        public ClassBox Sink
        {
            get { return edge.Sink; }
            set { edge.Sink = value; RaisePropertyChanged(() => Sink); }
        }

        public ClassBoxViewModel SourceVM;

        public ClassBoxViewModel SinkVM;


    }
}
