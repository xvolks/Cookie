package com.ankamagames.dofus.network.messages.game.interactive.zaap
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ZaapListMessage extends TeleportDestinationsListMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 1604;
       
      
      private var _isInitialized:Boolean = false;
      
      public var spawnMapId:uint = 0;
      
      public function ZaapListMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 1604;
      }
      
      public function initZaapListMessage(param1:uint = 0, param2:Vector.<uint> = null, param3:Vector.<uint> = null, param4:Vector.<uint> = null, param5:Vector.<uint> = null, param6:uint = 0) : ZaapListMessage
      {
         super.initTeleportDestinationsListMessage(param1,param2,param3,param4,param5);
         this.spawnMapId = param6;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.spawnMapId = 0;
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ZaapListMessage(param1);
      }
      
      public function serializeAs_ZaapListMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_TeleportDestinationsListMessage(param1);
         if(this.spawnMapId < 0)
         {
            throw new Error("Forbidden value (" + this.spawnMapId + ") on element spawnMapId.");
         }
         param1.writeInt(this.spawnMapId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ZaapListMessage(param1);
      }
      
      public function deserializeAs_ZaapListMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._spawnMapIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ZaapListMessage(param1);
      }
      
      public function deserializeAsyncAs_ZaapListMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._spawnMapIdFunc);
      }
      
      private function _spawnMapIdFunc(param1:ICustomDataInput) : void
      {
         this.spawnMapId = param1.readInt();
         if(this.spawnMapId < 0)
         {
            throw new Error("Forbidden value (" + this.spawnMapId + ") on element of ZaapListMessage.spawnMapId.");
         }
      }
   }
}
