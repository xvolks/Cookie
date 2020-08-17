package com.ankamagames.dofus.network.messages.game.inventory.preset
{
   import com.ankamagames.dofus.network.messages.game.inventory.AbstractPresetSaveMessage;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IdolsPresetSaveMessage extends AbstractPresetSaveMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6603;
       
      
      private var _isInitialized:Boolean = false;
      
      public function IdolsPresetSaveMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6603;
      }
      
      public function initIdolsPresetSaveMessage(param1:uint = 0, param2:uint = 0) : IdolsPresetSaveMessage
      {
         super.initAbstractPresetSaveMessage(param1,param2);
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
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
         this.serializeAs_IdolsPresetSaveMessage(param1);
      }
      
      public function serializeAs_IdolsPresetSaveMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPresetSaveMessage(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IdolsPresetSaveMessage(param1);
      }
      
      public function deserializeAs_IdolsPresetSaveMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IdolsPresetSaveMessage(param1);
      }
      
      public function deserializeAsyncAs_IdolsPresetSaveMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
      }
   }
}
