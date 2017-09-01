package com.ankamagames.dofus.network.types.game.guild.tax
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class TaxCollectorMovement implements INetworkType
   {
      
      public static const protocolId:uint = 493;
       
      
      public var movementType:uint = 0;
      
      public var basicInfos:TaxCollectorBasicInformations;
      
      public var playerId:Number = 0;
      
      public var playerName:String = "";
      
      private var _basicInfostree:FuncTree;
      
      public function TaxCollectorMovement()
      {
         this.basicInfos = new TaxCollectorBasicInformations();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 493;
      }
      
      public function initTaxCollectorMovement(param1:uint = 0, param2:TaxCollectorBasicInformations = null, param3:Number = 0, param4:String = "") : TaxCollectorMovement
      {
         this.movementType = param1;
         this.basicInfos = param2;
         this.playerId = param3;
         this.playerName = param4;
         return this;
      }
      
      public function reset() : void
      {
         this.movementType = 0;
         this.basicInfos = new TaxCollectorBasicInformations();
         this.playerName = "";
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TaxCollectorMovement(param1);
      }
      
      public function serializeAs_TaxCollectorMovement(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.movementType);
         this.basicInfos.serializeAs_TaxCollectorBasicInformations(param1);
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element playerId.");
         }
         param1.writeVarLong(this.playerId);
         param1.writeUTF(this.playerName);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TaxCollectorMovement(param1);
      }
      
      public function deserializeAs_TaxCollectorMovement(param1:ICustomDataInput) : void
      {
         this._movementTypeFunc(param1);
         this.basicInfos = new TaxCollectorBasicInformations();
         this.basicInfos.deserialize(param1);
         this._playerIdFunc(param1);
         this._playerNameFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorMovement(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorMovement(param1:FuncTree) : void
      {
         param1.addChild(this._movementTypeFunc);
         this._basicInfostree = param1.addChild(this._basicInfostreeFunc);
         param1.addChild(this._playerIdFunc);
         param1.addChild(this._playerNameFunc);
      }
      
      private function _movementTypeFunc(param1:ICustomDataInput) : void
      {
         this.movementType = param1.readByte();
         if(this.movementType < 0)
         {
            throw new Error("Forbidden value (" + this.movementType + ") on element of TaxCollectorMovement.movementType.");
         }
      }
      
      private function _basicInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.basicInfos = new TaxCollectorBasicInformations();
         this.basicInfos.deserializeAsync(this._basicInfostree);
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readVarUhLong();
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element of TaxCollectorMovement.playerId.");
         }
      }
      
      private function _playerNameFunc(param1:ICustomDataInput) : void
      {
         this.playerName = param1.readUTF();
      }
   }
}
