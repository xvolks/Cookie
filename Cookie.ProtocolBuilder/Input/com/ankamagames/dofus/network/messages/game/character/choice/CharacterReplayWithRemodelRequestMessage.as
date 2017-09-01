package com.ankamagames.dofus.network.messages.game.character.choice
{
   import com.ankamagames.dofus.network.messages.game.character.replay.CharacterReplayRequestMessage;
   import com.ankamagames.dofus.network.types.game.character.choice.RemodelingInformation;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CharacterReplayWithRemodelRequestMessage extends CharacterReplayRequestMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6551;
       
      
      private var _isInitialized:Boolean = false;
      
      public var remodel:RemodelingInformation;
      
      private var _remodeltree:FuncTree;
      
      public function CharacterReplayWithRemodelRequestMessage()
      {
         this.remodel = new RemodelingInformation();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6551;
      }
      
      public function initCharacterReplayWithRemodelRequestMessage(param1:Number = 0, param2:RemodelingInformation = null) : CharacterReplayWithRemodelRequestMessage
      {
         super.initCharacterReplayRequestMessage(param1);
         this.remodel = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.remodel = new RemodelingInformation();
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
         this.serializeAs_CharacterReplayWithRemodelRequestMessage(param1);
      }
      
      public function serializeAs_CharacterReplayWithRemodelRequestMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CharacterReplayRequestMessage(param1);
         this.remodel.serializeAs_RemodelingInformation(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterReplayWithRemodelRequestMessage(param1);
      }
      
      public function deserializeAs_CharacterReplayWithRemodelRequestMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.remodel = new RemodelingInformation();
         this.remodel.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterReplayWithRemodelRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_CharacterReplayWithRemodelRequestMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._remodeltree = param1.addChild(this._remodeltreeFunc);
      }
      
      private function _remodeltreeFunc(param1:ICustomDataInput) : void
      {
         this.remodel = new RemodelingInformation();
         this.remodel.deserializeAsync(this._remodeltree);
      }
   }
}
