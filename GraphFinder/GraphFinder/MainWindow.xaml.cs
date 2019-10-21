﻿using GraphFinder.Entity;
using GraphFinder.Model;
using GraphFinder.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphFinder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Graph graph;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*graph = new Graph();

            Node node1 = new Node(new Point(1, 2), "s");
            Node node2 = new Node(new Point(4, 1), "1");
            Node node3 = new Node(new Point(2, 2), "2");
            Node node4 = new Node(new Point(5, 2), "3");
            Node node5 = new Node(new Point(3, 3), "4");
            Node node6 = new Node(new Point(4, 4), "5");
            Node node7 = new Node(new Point(6, 1), "e");
            
            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddNode(node5);
            graph.AddNode(node6);
            graph.AddNode(node7);

            Edge edge1 = new Edge(node1, node2, 1);
            Edge edge2 = new Edge(node1, node3, 1);
            edge2.IsPath = true;
            Edge edge3 = new Edge(node2, node3, 1);
            Edge edge4 = new Edge(node2, node4, 1);
            Edge edge5 = new Edge(node2, node5, 1);
            Edge edge6 = new Edge(node3, node4, 1);
            Edge edge7 = new Edge(node4, node5, 1);
            Edge edge8 = new Edge(node4, node6, 1);
            Edge edge9 = new Edge(node5, node6, 1);
            Edge edge10 = new Edge(node5, node7, 1);
            Edge edge11 = new Edge(node6, node7, 1);

            graph.AddEdge(edge1);
            graph.AddEdge(edge2);
            graph.AddEdge(edge3);
            graph.AddEdge(edge4);
            graph.AddEdge(edge5);
            graph.AddEdge(edge6);
            graph.AddEdge(edge7);
            graph.AddEdge(edge8);
            graph.AddEdge(edge9);
            graph.AddEdge(edge10);
            graph.AddEdge(edge11);

            Painter painter = new Painter(canvas1, graph);
            painter.Draw();*/

            erText.Text = "";

            GraphGenerator graphGenerator = new GraphGenerator();
            int nodeCount = 5;
            int percent = 70;
            int width = 5;

            try
            {
                nodeCount = Int32.Parse(nodeCountTextBox.Text);
                percent = Int32.Parse(percentTextBox.Text);
                width = Int32.Parse(widthTextBox.Text);
            }
            catch
            {
                erText.Text = "Только целые числа";
            }

            graphGenerator.Width = width;

            graph = graphGenerator.Generate(nodeCount);

            graph.Percent = percent;

            graph.RefactorGraph();

            nodeGrid.ItemsSource = graph.Nodes;
            edgeGrid.ItemsSource = graph.Edges;

            PathConstanse pathConstanse = new PathConstanse();
            PathFinder pathFinder = new PathFinder(pathConstanse, graph);

            pathFinder.Search();

            Painter painter = new Painter(canvas1, graph);
            painter.Draw();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            erText.Text = "";

            try
            {
                Painter painter = new Painter(canvas1, graph);
                painter.Draw();
            }
            catch
            {
                erText.Text = "Сгенерируйте граф";
            }
        }
    }
}
