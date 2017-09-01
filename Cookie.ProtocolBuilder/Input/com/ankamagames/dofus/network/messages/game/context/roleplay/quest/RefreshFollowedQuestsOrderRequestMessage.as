package com.ankamagames.dofus.network.messages.game.context.roleplay.quest
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class RefreshFollowedQuestsOrderRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6722;
       
      
      private var _isInitialized:Boolean = false;
      
      public var quests:Vector.<uint>;
      
      private var _queststree:FuncTree;
      
      public function RefreshFollowedQuestsOrderRequestMessage()
      {
         this.quests = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6722;
      }
      
      public function initRefreshFollowedQuestsOrderRequestMessage(param1:Vector.<uint> = null) : RefreshFollowedQuestsOrderRequestMessage
      {
         this.quests = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.quests = new Vector.<uint>();
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
         this.serializeAs_RefreshFollowedQuestsOrderRequestMessage(param1);
      }
      
      public function serializeAs_RefreshFollowedQuestsOrderRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.quests.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.quests.length)
         {
            if(this.quests[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.quests[_loc2_] + ") on element 1 (starting at 1) of quests.");
            }
            param1.writeVarShort(this.quests[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_RefreshFollowedQuestsOrderRequestMessage(param1);
      }
      
      public function deserializeAs_RefreshFollowedQuestsOrderRequestMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readVarUhShort();
            if(_loc4_ < 0)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of quests.");
            }
            this.quests.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_RefreshFollowedQuestsOrderRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_RefreshFollowedQuestsOrderRequestMessage(param1:FuncTree) : void
      {
         this._queststree = param1.addChild(this._queststreeFunc);
      }
      
      private function _queststreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._queststree.addChild(this._questsFunc);
            _loc3_++;
         }
      }
      
      private function _questsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of quests.");
         }
         this.quests.push(_loc2_);
      }
   }
}
