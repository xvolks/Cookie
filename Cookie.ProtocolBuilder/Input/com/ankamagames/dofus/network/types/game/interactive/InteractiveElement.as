package com.ankamagames.dofus.network.types.game.interactive
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class InteractiveElement implements INetworkType
   {
      
      public static const protocolId:uint = 80;
       
      
      public var elementId:uint = 0;
      
      public var elementTypeId:int = 0;
      
      public var enabledSkills:Vector.<InteractiveElementSkill>;
      
      public var disabledSkills:Vector.<InteractiveElementSkill>;
      
      public var onCurrentMap:Boolean = false;
      
      private var _enabledSkillstree:FuncTree;
      
      private var _disabledSkillstree:FuncTree;
      
      public function InteractiveElement()
      {
         this.enabledSkills = new Vector.<InteractiveElementSkill>();
         this.disabledSkills = new Vector.<InteractiveElementSkill>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 80;
      }
      
      public function initInteractiveElement(param1:uint = 0, param2:int = 0, param3:Vector.<InteractiveElementSkill> = null, param4:Vector.<InteractiveElementSkill> = null, param5:Boolean = false) : InteractiveElement
      {
         this.elementId = param1;
         this.elementTypeId = param2;
         this.enabledSkills = param3;
         this.disabledSkills = param4;
         this.onCurrentMap = param5;
         return this;
      }
      
      public function reset() : void
      {
         this.elementId = 0;
         this.elementTypeId = 0;
         this.enabledSkills = new Vector.<InteractiveElementSkill>();
         this.disabledSkills = new Vector.<InteractiveElementSkill>();
         this.onCurrentMap = false;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_InteractiveElement(param1);
      }
      
      public function serializeAs_InteractiveElement(param1:ICustomDataOutput) : void
      {
         if(this.elementId < 0)
         {
            throw new Error("Forbidden value (" + this.elementId + ") on element elementId.");
         }
         param1.writeInt(this.elementId);
         param1.writeInt(this.elementTypeId);
         param1.writeShort(this.enabledSkills.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.enabledSkills.length)
         {
            param1.writeShort((this.enabledSkills[_loc2_] as InteractiveElementSkill).getTypeId());
            (this.enabledSkills[_loc2_] as InteractiveElementSkill).serialize(param1);
            _loc2_++;
         }
         param1.writeShort(this.disabledSkills.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.disabledSkills.length)
         {
            param1.writeShort((this.disabledSkills[_loc3_] as InteractiveElementSkill).getTypeId());
            (this.disabledSkills[_loc3_] as InteractiveElementSkill).serialize(param1);
            _loc3_++;
         }
         param1.writeBoolean(this.onCurrentMap);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InteractiveElement(param1);
      }
      
      public function deserializeAs_InteractiveElement(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:InteractiveElementSkill = null;
         var _loc8_:uint = 0;
         var _loc9_:InteractiveElementSkill = null;
         this._elementIdFunc(param1);
         this._elementTypeIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readUnsignedShort();
            _loc7_ = ProtocolTypeManager.getInstance(InteractiveElementSkill,_loc6_);
            _loc7_.deserialize(param1);
            this.enabledSkills.push(_loc7_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc8_ = param1.readUnsignedShort();
            _loc9_ = ProtocolTypeManager.getInstance(InteractiveElementSkill,_loc8_);
            _loc9_.deserialize(param1);
            this.disabledSkills.push(_loc9_);
            _loc5_++;
         }
         this._onCurrentMapFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InteractiveElement(param1);
      }
      
      public function deserializeAsyncAs_InteractiveElement(param1:FuncTree) : void
      {
         param1.addChild(this._elementIdFunc);
         param1.addChild(this._elementTypeIdFunc);
         this._enabledSkillstree = param1.addChild(this._enabledSkillstreeFunc);
         this._disabledSkillstree = param1.addChild(this._disabledSkillstreeFunc);
         param1.addChild(this._onCurrentMapFunc);
      }
      
      private function _elementIdFunc(param1:ICustomDataInput) : void
      {
         this.elementId = param1.readInt();
         if(this.elementId < 0)
         {
            throw new Error("Forbidden value (" + this.elementId + ") on element of InteractiveElement.elementId.");
         }
      }
      
      private function _elementTypeIdFunc(param1:ICustomDataInput) : void
      {
         this.elementTypeId = param1.readInt();
      }
      
      private function _enabledSkillstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._enabledSkillstree.addChild(this._enabledSkillsFunc);
            _loc3_++;
         }
      }
      
      private function _enabledSkillsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:InteractiveElementSkill = ProtocolTypeManager.getInstance(InteractiveElementSkill,_loc2_);
         _loc3_.deserialize(param1);
         this.enabledSkills.push(_loc3_);
      }
      
      private function _disabledSkillstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._disabledSkillstree.addChild(this._disabledSkillsFunc);
            _loc3_++;
         }
      }
      
      private function _disabledSkillsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:InteractiveElementSkill = ProtocolTypeManager.getInstance(InteractiveElementSkill,_loc2_);
         _loc3_.deserialize(param1);
         this.disabledSkills.push(_loc3_);
      }
      
      private function _onCurrentMapFunc(param1:ICustomDataInput) : void
      {
         this.onCurrentMap = param1.readBoolean();
      }
   }
}
