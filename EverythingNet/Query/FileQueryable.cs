﻿namespace EverythingNet.Query
{
  using System.Collections.Generic;

  using EverythingNet.Interfaces;

  internal class FileQueryable : Queryable, IFileQueryable
  {
    private const string AudioExt = "aac;ac3;aif;aifc;aiff;au;cda;dts;fla;flac;it;m1a;m2a;m3u;m4a;mid;midi;mka;mod;mp2;mp3;mpa;ogg;ra;rmi;spc;rmi;snd;umx;voc;wav;wma;xm";
    private const string ZipExt = "7z;ace;arj;bz2;cab;gz;gzip;jar;r00;r01;r02;r03;r04;r05;r06;r07;r08;r09;r10;r11;r12;r13;r14;r15;r16;r17;r18;r19;r20;r21;r22;r23;r24;r25;r26;r27;r28;r29;rar;tar;tgz;z;zip";
    private const string DocExt = "c;chm;cpp;csv;cxx;doc;docm;docx;dot;dotm;dotx;h;hpp;htm;html;hxx;ini;java;lua;mht;mhtml;odt;pdf;potx;potm;ppam;ppsm;ppsx;pps;ppt;pptm;pptx;rtf;sldm;sldx;thmx;txt;vsd;wpd;wps;wri;xlam;xls;xlsb;xlsm;xlsx;xltm;xltx;xml";
    private const string ExeExt = "bat;cmd;exe;msi;msp;msu;scr";
    private const string PicsExt = "ani;bmp;gif;ico;jpe;jpeg;jpg;pcx;png;psd;tga;tif;tiff;wmf";
    private const string VideoExt = "3g2;3gp;3gp2;3gpp;amr;amv;asf;avi;bdmv;bik;d2v;divx;drc;dsa;dsm;dss;dsv;evo;f4v;flc;fli;flic;flv;hdmov;ifo;ivf;m1v;m2p;m2t;m2ts;m2v;m4b;m4p;m4v;mkv;mp2v;mp4;mp4v;mpe;mpeg;mpg;mpls;mpv2;mpv4;mov;mts;ogm;ogv;pss;pva;qt;ram;ratdvd;rm;rmm;rmvb;roq;rpm;smil;smk;swf;tp;tpr;ts;vob;vp6;webm;wm;wmp;wmv";

    private string searchPattern;

    public FileQueryable(IEverythingInternal everything, IQueryGenerator parent)
      : base(everything, parent)
    {
    }

    public override IEnumerable<string> GetQueryParts()
    {
      foreach (var queryPart in base.GetQueryParts())
      {
        yield return queryPart;
      }

      if (!string.IsNullOrEmpty(this.searchPattern))
      {
        yield return this.searchPattern;
      }
    }

    public IQueryable Only()
    {
      return this.Macro("file:", string.Empty);
    }

    public IQueryable Audio(string search = null)
    {
      return this.Macro($"ext:{AudioExt}", search);
    }

    public IQueryable Zip(string search = null)
    {
      return this.Macro($"ext:{ZipExt}", search);
    }

    public IQueryable Video(string search = null)
    {
      return this.Macro($"ext:{VideoExt}", search);
    }

    public IQueryable Picture(string search = null)
    {
      return this.Macro($"ext:{PicsExt}", search);
    }

    public IQueryable Exe(string search = null)
    {
      return this.Macro($"ext:{ExeExt}", search);
    }

    public IQueryable Document(string search = null)
    {
      return this.Macro($"ext:{DocExt}", search);
    }

    public IQueryable Duplicates(string search = null)
    {
      return this.Macro("dupe:", search);
    }

    private IQueryable Macro(string tag, string search)
    {
      this.searchPattern = string.IsNullOrEmpty(search)
        ? tag
        : $"{tag} {this.QuoteIfNeeded(search)}";

      return this;
    }
  }
}