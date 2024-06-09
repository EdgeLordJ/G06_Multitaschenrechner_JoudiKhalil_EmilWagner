## Joudi
| Tag    | Was gemacht?                                                                                                          |
| ------ | --------------------------------------------------------------------------------------------------------------------- |
| 24.04. | Planung                                                                                                               |
| 01.05. | Normaler Taschenrechner Basis Design gemacht                                                                          |
| 08.05. | Normaler Taschenrechner hälfte fertig, Paket "ncalc" installiert; an Doku gearbeitet                                  |
| 15.05. | Prozent, negieren, Hoch 2, Wurzel, 1 Durch x fertig; Komma fertig angepasst; Klammern Funktionalität geändert         |
| 22.05. | Normaler Taschenrechner fertig; Logging fehlt noch                                                                    |
| 24.05. | Logging Pakete installiert; Normaler Taschenrechner nötige Logs gemacht; offiziell fertig mit Normaler Taschenrechner |
| 26.05. | Neues UserControl Fenster hinzugefügt für den Währungrechner bzw. Währungsrechner angefangen; Basis Design fertig     |
| 29.05. | Währungsrechner fast fertig                                                                                           |
| 04.06. | Währungsrechner fertiggestellt Logging fehlt                                                                          |
| 05.06. | Währungsvergleich angefangen und 3/4 fertig richtige Balken vom Diagramm fehlen                                       |
| 06.06. | Dezimalstelle Bug behoben bei Währungsrechner und Funktionalitäten verbessert; Währungsvergleich fertig fehlt Logging |
| 08.06. | Logging bei Währungsrechner, Währungsvergleich, und Taschenrechner gemacht; Taschenrechner Bugs behandelt             |
| 09.06. | Temperaturrechner fertiggestellt mit Logging                                                                          |

## Probleme
| Problem                                                                    | Lösung                                                                                                                                                                                        |
| -------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Die Logik hinter der Einabe der einzelnen Zahlen und Zeichen               | 5h lang dran geblieben um es zu lösen.                                                                                                                                                        |
| Problem mit dem Dezimaltrennzeichen, dass es "." ignoriert                 | Herausgefunden das es Kulturabhängig ist und man muss es mit einer Zeile Code ändern, dass "." als Dezimaltrennzeichen verwendet wird                                                         |
| API Wahl, weil viele APIs Zahlungsbedingt sind und vielleicht betrügerisch | Herr Diem um Hilfe gebittet und dank Herr Diem eine gefunden                                                                                                                                  |
| Beim Währungsvergleich: Die Höhe der Balken im Diagramm => waren zu klein  | Herausgefunden das man mit logarithmischem Skalieren die kleinen Werte vergrößern kann und die großen Werte komprimieren kann (Habe es in Mathe gelernt, aber ist mir recht Spät aufgefallen) |