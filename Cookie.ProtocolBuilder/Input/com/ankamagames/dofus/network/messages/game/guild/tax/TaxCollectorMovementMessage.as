package com.ankamagames.dofus.network.messages.game.guild.tax
{
   import com.ankamagames.dofus.network.types.game.guild.tax.TaxCollectorBasicInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TaxCollectorMovementMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5633;
       
      
      private var _isInitialized:Boolean = false;
      
      public var movementType:uint = 0;
      
      public var basicInfos:TaxCollectorBasicInformations;
      
      public var playerId:Number = 0;
      
      public var playerName:String = "";
      
      private var _basicInfostree:FuncTree;
      
      public function TaxCollectorMovementMessage()
      {
         this.basicInfos = new TaxCollectorBasicInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5633;
      }
      
      public function initTaxCollectorMovementMessage(param1:uint = 0, param2:TaxCollectorBasicInformations = null, param3:Number = 0, param4:String = "") : TaxCollectorMovementMessage
      {
         this.movementType = param1;
         this.basicInfos = param2;
         this.playerId = param3;
         this.playerName = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.movementType = 0;
         this.basicInfos = new TaxCollectorBasicInformations();
         this.playerName = "";
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TaxCollectorMovementMessage(param1);
      }
      
      public function serializeAs_TaxCollectorMovementMessage(param1:ICustomDataOutput) : void
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
         this.deserializeAs_TaxCollectorMovementMessage(param1);
      }
      
      public function deserializeAs_TaxCollectorMovementMessage(param1:ICustomDataInput) : void
      {
         this._movementTypeFunc(param1);
         this.basicInfos = new TaxCollectorBasicInformations();
         this.basicInfos.deserialize(param1);
         this._playerIdFunc(param1);
         this._playerNameFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorMovementMessage(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorMovementMessage(param1:FuncTree) : void
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
            throw new Error("Forbidden value (" + this.movementType + ") on element of TaxCollectorMovementMessage.movementType.");
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
            throw new Error("Forbidden value (" + this.playerId + ") on element of TaxCollectorMovementMessage.playerId.");
         }
      }
      
      private function _playerNameFunc(param1:ICustomDataInput) : void
      {
         this.playerName = param1.readUTF();
      }
   }
}
