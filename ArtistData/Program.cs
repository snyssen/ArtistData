using ArtistData.Models;
using System;
using System.IO;

namespace ArtistData
{
    public class Program

    {

        static void Main(string[] args)

        {

            //using (var context = new ArtistContext())

            //{

            //    using (var reader = new StreamReader(@"C:\Users\dahi1\musicbrainzdata\mbdump\artist"))

            //    {
            //        int counter = 1;

            //        while (!reader.EndOfStream)

            //        {

            //            var line = reader.ReadLine();

            //            Console.WriteLine(line);

            //            var values = line.Split('\t');

            //            Console.WriteLine($"Extracted {values.Length} values");

            //            Artist art;

            //            try
            //            {


            //                art = new Artist() // See order here -> https://github.com/metabrainz/musicbrainz-server/blob/master/admin/sql/CreateTables.sql#L208

            //                {

            //                    Gid = new Guid(values[1]),

            //                    Name = values[2],

            //                    Sort_name = values[3],

            //                    Begin_date_year = values[4] == "\\N" ? null : (int?)int.Parse(values[4]),

            //                    Begin_date_month = values[5] == "\\N" ? null : (int?)int.Parse(values[5]),
            //                    Begin_date_day = values[6] == "\\N" ? null : (int?)int.Parse(values[6]),
            //                    End_date_year = values[7] == "\\N" ? null : (int?)int.Parse(values[7]),
            //                    End_date_month = values[8] == "\\N" ? null : (int?)int.Parse(values[8]),
            //                    End_date_day = values[9] == "\\N" ? null : (int?)int.Parse(values[9]),
            //                    Type = values[10] == "\\N" ? null : (int?)int.Parse(values[10]),
            //                    Area = values[11] == "\\N" ? null : (int?)int.Parse(values[11]),
            //                    Gender = values[12] == "\\N" ? null : (int?)int.Parse(values[12]),

            //                    Comment = values[13],
            //                    Edits_pending = values[14] == "\\0" ? null : (int?)int.Parse(values[14]),
            //                    Last_updated = values[15] == "\\N" ? null : (DateTime?)DateTime.Parse(values[15]),
            //                    Ended = values[16] == "t",
            //                    Begin_area = values[17] == "\\N" ? null : (int?)int.Parse(values[17]),
            //                    End_area = values[18] == "\\N" ? null : (int?)int.Parse(values[18])
            //                };

            //            }
            //            catch (Exception e)
            //            {

            //                Console.WriteLine(e);

            //                continue;

            //            }

            //            Console.WriteLine($"Successfully parsed artist {art.Name}");



            //            context.Artists.Add(art);

            //            if (counter >= 100)
            //            {
            //                try
            //                {
            //                    Console.WriteLine("Saving batch of artists to DB...");
            //                    var result = context.SaveChanges();
            //                    Console.WriteLine($"Saved {result} artists !");
            //                    counter = 0;
            //                }
            //                catch (Exception e)
            //                {
            //                    Console.WriteLine("Couldn't save artists to database");
            //                    Console.WriteLine(e);
            //                    return;
            //                }
            //            }

            //            counter++;
            //        }
            //    }

            //    try
            //    {
            //        Console.WriteLine("Finished parsing artists, saving to database...");
            //        var result = context.SaveChanges();
            //        Console.WriteLine($"Saved {result} artists !");
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Couldn't save artists to database");
            //        Console.WriteLine(e);
            //        return;
            //    }
            //}
            using (var context = new ArtistContext())

            {

                using (var reader = new StreamReader(@"C:\Users\dahi1\musicbrainzdata\mbdump\release"))

                {
                    int counter = 1;

                    while (!reader.EndOfStream)

                    {

                        var line = reader.ReadLine();

                        Console.WriteLine(line);

                        var values = line.Split('\t');

                        Console.WriteLine($"Extracted {values.Length} values");

                        Release rel;

                        try
                        {


                            rel = new Release() // See order here -> https://github.com/metabrainz/musicbrainz-server/blob/master/admin/sql/CreateTables.sql#L208

                            {

                                Gid = new Guid(values[1]),

                                Name = values[2],

                                Artist_credit = int.Parse(values[3]),

                                Release_group = int.Parse(values[4]),

                                Status = values[5] == "\\N" ? null : (int?)int.Parse(values[5]),
                                Packaging = values[6] == "\\N" ? null : (int?)int.Parse(values[6]),
                                Language = values[7] == "\\N" ? null : (int?)int.Parse(values[7]),
                                Script = values[8] == "\\N" ? null : (int?)int.Parse(values[8]),
                                Barcode = values[9],
                                Comment = values[10],
                                Edits_pending = values[11] == "\\0" ? null : (int?)int.Parse(values[11]),
                                Quality = values[12] == "\\-1" ? null : (int?)int.Parse(values[12]),
                                Last_updated = values[13] == "\\N" ? null : (DateTime?)DateTime.Parse(values[13])
                                
                            };

                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e);

                            continue;

                        }

                        Console.WriteLine($"Successfully parsed release {rel.Name}");



                        context.Releases.Add(rel);

                        if (counter >= 100)
                        {
                            try
                            {
                                Console.WriteLine("Saving batch of releases to DB...");
                                var result = context.SaveChanges();
                                Console.WriteLine($"Saved {result} releases !");
                                counter = 0;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Couldn't save releases to database");
                                Console.WriteLine(e);
                                return;
                            }
                        }

                        counter++;
                    }
                }

                try
                {
                    Console.WriteLine("Finished parsing releases, saving to database...");
                    var result = context.SaveChanges();
                    Console.WriteLine($"Saved {result} releases !");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Couldn't save releases to database");
                    Console.WriteLine(e);
                    return;
                }
            }
        }
    }
}
