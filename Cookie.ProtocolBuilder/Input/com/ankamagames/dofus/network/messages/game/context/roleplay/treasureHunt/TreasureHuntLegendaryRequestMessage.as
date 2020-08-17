package com.ankamagames.dofus.network.messages.game.context.roleplay.treasureHunt
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TreasureHuntLegendaryRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6499;
       
      
      private var _isInitialized:Boolean = false;
      
      public var legendaryId:uint = 0;
      
      public function TreasureHuntLegendaryRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6499;
      }
      
      public function initTreasureHuntLegendaryRequestMessage(param1:uint = 0) : TreasureHuntLegendaryRequestMessage
      {
         this.legendaryId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.legendaryId = 0;
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
         this.serializeAs_TreasureHuntLegendaryRequestMessage(param1);
      }
      
      public function serializeAs_TreasureHuntLegendaryRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.legendaryId < 0)
         {
            throw new Error("Forbidden value (" + this.legendaryId + ") on element legendaryId.");
         }
         param1.writeVarShort(this.legendaryId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TreasureHuntLegendaryRequestMessage(param1);
      }
      
      public function deserializeAs_TreasureHuntLegendaryRequestMessage(param1:ICustomDataInput) : void
      {
         this._legendaryIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TreasureHuntLegendaryRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_TreasureHuntLegendaryRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._legendaryIdFunc);
      }
      
      private function _legendaryIdFunc(param1:ICustomDataInput) : void
      {
         this.legendaryId = param1.readVarUhShort();
         if(this.legendaryId < 0)
         {
            throw new Error("Forbidden value (" + this.legendaryId + ") on element of TreasureHuntLegendaryRequestMessage.legendaryId.");
         }
      }
   }
}
